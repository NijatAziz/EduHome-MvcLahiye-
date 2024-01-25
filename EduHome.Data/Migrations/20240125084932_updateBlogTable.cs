using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.Data.Migrations
{
    public partial class updateBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Authors_AuthorID",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AuhorId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Blogs",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AuthorID",
                table: "Blogs",
                newName: "IX_Blogs_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Authors_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Authors_AuthorId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Blogs",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                newName: "IX_Blogs_AuthorID");

            migrationBuilder.AddColumn<int>(
                name: "AuhorId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Authors_AuthorID",
                table: "Blogs",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
