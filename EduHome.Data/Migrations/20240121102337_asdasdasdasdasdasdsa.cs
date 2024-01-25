using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.Data.Migrations
{
    public partial class asdasdasdasdasdasdsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Courses",
                newName: "Desc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Courses",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
