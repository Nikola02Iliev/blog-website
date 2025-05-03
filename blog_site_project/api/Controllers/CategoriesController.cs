using api.DTOs.CategoryDTOs;
using api.Mappers;
using api.Responses.CategoryResponses;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync
        (
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "CategoryId",
            [FromQuery] string sortOrder = "asc",
            [FromQuery] string filter = ""
        )
        {
            var categories = await _categoriesService.GetPagedCategoriesAsync(page, pageSize, sortBy, sortOrder, filter);
            return Ok(categories);
        }

        [HttpGet("get-category/{categoryId}")]
        public async Task<IActionResult> GetCategoryDetailsAsync(int categoryId)
        {
            var existingCategory = await _categoriesService.GetCategoryAsync(categoryId);

            if (existingCategory == null)
            {
                return NotFound("Category not found");
            }

            var toDetailsCategoryDTO = existingCategory.ToDetailsCategoryDTO();

            return Ok(toDetailsCategoryDTO);
        }

        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            if (await _categoriesService.CategoryExists(createCategoryDTO.CategoryName))
            {
                return BadRequest("Category already exists");
            }

            var createdCategory = createCategoryDTO.ToCategoryFromCreateCategoryDTO();

            await _categoriesService.CreateCategoryAsync(createdCategory);

            return Ok(new CreateCategoryResponse
            {
                CategoryId = createdCategory.CategoryId,
                CategoryName = createCategoryDTO.CategoryName,
                CreatedAt = createdCategory.CreatedAt
            });

        }

        [HttpPut("update-category/{categoryId}")]
        public async Task<IActionResult> UpdateCategoryAsync(int categoryId, UpdateCategoryDTO updateCategoryDTO)
        {
            if (await _categoriesService.CategoryExists(updateCategoryDTO.CategoryName))
            {
                return BadRequest("Category already exists");
            }

            var updatedCategory = await _categoriesService.GetCategoryAsync(categoryId);

            if (updatedCategory == null)
            {
                return NotFound("Category not found");
            }

            await _categoriesService.UpdateCategoryAsync(updatedCategory, updateCategoryDTO);

            return Ok(new UpdateCategoryResponse
            {
                CategoryId = updatedCategory.CategoryId,
                CategoryName = updatedCategory.CategoryName,
                UpdatedAt = updatedCategory.UpdatedAt
            });

        }

        [HttpDelete("delete-category/{categoryId}")]
        public async Task<IActionResult> DeleteCategoryAsync(int categoryId)
        {
            var deletedCategory = await _categoriesService.GetCategoryAsync(categoryId);

            if (deletedCategory == null)
            {
                return NotFound("Category not found");
            }

            await _categoriesService.DeleteCategoryAsync(deletedCategory);

            return Ok("Category deleted");
        }


    }
}
