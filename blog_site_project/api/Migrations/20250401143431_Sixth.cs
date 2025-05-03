using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "6d8435c0-ee3a-404a-9ef5-cdce4b92c719" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d8435c0-ee3a-404a-9ef5-cdce4b92c719");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8de61c4a-acf8-4f58-be1c-bb43d33fa59d", 0, "cc81d668-bc54-471d-b59b-5db805c52436", "admin@domain.com", true, false, null, "ADMIN@DOMAIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEKYaZ7ofntHKjONzadeIlcYH6eMHeZHQinef3eBJ9DJxgUZd6wIa3OGV4tlvBi+Cfg==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "8de61c4a-acf8-4f58-be1c-bb43d33fa59d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "8de61c4a-acf8-4f58-be1c-bb43d33fa59d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8de61c4a-acf8-4f58-be1c-bb43d33fa59d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d8435c0-ee3a-404a-9ef5-cdce4b92c719", 0, "ae4bb681-6e0d-46a3-ad5c-353e433b5c8f", "admin@domain.com", true, false, null, "ADMIN@DOMAIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEFVOqyh15cOCe7ZOg+4FnETr/T65OfZsU/V6prNECts1dC3TWJKrDa2XogVyBhViLg==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "6d8435c0-ee3a-404a-9ef5-cdce4b92c719" });
        }
    }
}
