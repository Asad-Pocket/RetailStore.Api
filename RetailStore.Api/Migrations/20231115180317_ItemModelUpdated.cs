using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetailStore.Api.Migrations
{
    public partial class ItemModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "ItemList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "ItemList",
                type: "datetime2",
                nullable: true);
        }
    }
}
