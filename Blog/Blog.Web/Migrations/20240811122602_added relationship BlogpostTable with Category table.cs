﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Web.Migrations
{
    /// <inheritdoc />
    public partial class addedrelationshipBlogpostTablewithCategorytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
              name: "FK_BlogPosts_Categories_CategoryId",
              table: "BlogPosts",
              column: "CategoryId",
              principalTable: "Categories",
              principalColumn: "Id",
              onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Categories_CategoryId",
                table: "BlogPosts");

        }
    }
}
