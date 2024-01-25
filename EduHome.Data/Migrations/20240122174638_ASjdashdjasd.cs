using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.Data.Migrations
{
    public partial class ASjdashdjasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Certification",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HowToApply",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Certification",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "HowToApply",
                table: "Courses");
        }
    }
}
