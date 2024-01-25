using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.Data.Migrations
{
    public partial class asdasdasdasdasdasdsaasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Courses_CourseID",
                table: "Features");

            migrationBuilder.DropTable(
                name: "CategoryCourse");

            migrationBuilder.DropIndex(
                name: "IX_Features_CourseID",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Features");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FeatureId",
                table: "Courses",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Features_FeatureId",
                table: "Courses",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Features_FeatureId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_FeatureId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryCourse",
                columns: table => new
                {
                    CategoriesID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCourse", x => new { x.CategoriesID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_CategoryCourse_Categories_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCourse_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_CourseID",
                table: "Features",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCourse_CourseID",
                table: "CategoryCourse",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Courses_CourseID",
                table: "Features",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID");
        }
    }
}
