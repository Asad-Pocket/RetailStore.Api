using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetailStore.Api.Migrations
{
    public partial class updateRoleinUserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserDetailsList",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserDetailsList");
        }
    }
}
