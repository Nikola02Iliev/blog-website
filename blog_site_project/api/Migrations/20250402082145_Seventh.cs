using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Seventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "8de61c4a-acf8-4f58-be1c-bb43d33fa59d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8de61c4a-acf8-4f58-be1c-bb43d33fa59d");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "da21d6a9-fec3-45f9-bbe3-23b6f6cd5c92", 0, "872c4c6f-17bf-4185-8d9d-0b3ea4b3343d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@domain.com", true, false, null, "ADMIN@DOMAIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEBXgvy4xOMASrfvgr+8etEW6HfIUNDE2DhQ2/zc0FIoDrqHI6vFT0jGU+AuDTvZDGQ==", null, false, "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "da21d6a9-fec3-45f9-bbe3-23b6f6cd5c92" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "da21d6a9-fec3-45f9-bbe3-23b6f6cd5c92" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da21d6a9-fec3-45f9-bbe3-23b6f6cd5c92");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8de61c4a-acf8-4f58-be1c-bb43d33fa59d", 0, "cc81d668-bc54-471d-b59b-5db805c52436", "admin@domain.com", true, false, null, "ADMIN@DOMAIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEKYaZ7ofntHKjONzadeIlcYH6eMHeZHQinef3eBJ9DJxgUZd6wIa3OGV4tlvBi+Cfg==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "8de61c4a-acf8-4f58-be1c-bb43d33fa59d" });
        }
    }
}
