using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.Data.Migrations
{
    public partial class addedAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuhorId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorID",
                table: "Blogs",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Authors_AuthorID",
                table: "Blogs",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Authors_AuthorID",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_AuthorID",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AuhorId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Blogs");
        }
    }
}
