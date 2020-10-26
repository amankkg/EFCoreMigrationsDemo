using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMigrations.Migrations
{
    public partial class RenameResidentEnteredDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entered",
                table: "Residents");

            migrationBuilder.AddColumn<DateTime>(
                name: "EnteredDate",
                table: "Residents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnteredDate",
                table: "Residents");

            migrationBuilder.AddColumn<DateTime>(
                name: "Entered",
                table: "Residents",
                type: "datetime2",
                nullable: true);
        }
    }
}
