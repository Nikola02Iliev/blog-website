using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d8435c0-ee3a-404a-9ef5-cdce4b92c719", 0, "ae4bb681-6e0d-46a3-ad5c-353e433b5c8f", "admin@domain.com", true, false, null, "ADMIN@DOMAIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEFVOqyh15cOCe7ZOg+4FnETr/T65OfZsU/V6prNECts1dC3TWJKrDa2XogVyBhViLg==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "6d8435c0-ee3a-404a-9ef5-cdce4b92c719" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1", 0, "9b9aaef4-a6b4-4f02-b74e-d38150fb20c2", "admin@domain.com", true, false, null, "ADMIN@DOMAIN.COM", "ADMIN", "AQAAAAIAAYagAAAAED1h3n2YYSUTCm9YPtqhWhjV+sDKTMaSnDXCnvXoakErGUeBmtwVu6Yxf8wePFKo1g==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }
    }
}
