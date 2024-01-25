using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.Data.Migrations
{
    public partial class asdasdasdasdasdasdsaasdasdsad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Features",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Features",
                newName: "Assesments");

            migrationBuilder.AddColumn<byte>(
                name: "ClassDuration",
                table: "Features",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<decimal>(
                name: "CourseFee",
                table: "Features",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte>(
                name: "Duration",
                table: "Features",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Level",
                table: "Features",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Starts",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Students",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassDuration",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CourseFee",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Starts",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Students",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Features",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Assesments",
                table: "Features",
                newName: "Key");
        }
    }
}
