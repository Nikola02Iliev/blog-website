using api.DTOs.CategoryDTOs;
using api.Models;

namespace api.Mappers
{
    public static class CategoriesMapper
    {
        public static ListCategoryDTO ToListCategoryDTO(this Category category)
        {
            return new ListCategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public static DetailsCategoryDTO ToDetailsCategoryDTO(this Category category)
        {
            return new DetailsCategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                CreatedAt = category.CreatedAt
            };
        }

        public static Category ToCategoryFromCreateCategoryDTO(this CreateCategoryDTO createCategoryDTO)
        {
            return new Category
            {
                CategoryName = createCategoryDTO.CategoryName
            };
        }

        public static ListCategoryDTOInListPostDTO ToListCategoryDTOInListPostDTO(this Category category)
        {
            return new ListCategoryDTOInListPostDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public static ListCategoryDTOInDetailsPostDTO ToListCategoryDTOInDetailsPostDTO(this Category category)
        {
            return new ListCategoryDTOInDetailsPostDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

    }
}
