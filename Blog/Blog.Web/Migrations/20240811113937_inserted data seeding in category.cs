using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Web.Migrations
{
    /// <inheritdoc />
    public partial class inserteddataseedingincategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("de58c8a3-2b90-4b86-abfe-3a31e9f2bd05"), "General" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("de58c8a3-2b90-4b86-abfe-3a31e9f2bd05"));
        }
    }
}
