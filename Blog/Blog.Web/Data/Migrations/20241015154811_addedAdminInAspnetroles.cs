using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedAdminInAspnetroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5da1f6bf-7fff-48c4-8f37-f7e359c8dfa2"), "520266c3-aea2-4ecb-a45a-90274b2a53c8", "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5da1f6bf-7fff-48c4-8f37-f7e359c8dfa2"));
        }
    }
}
