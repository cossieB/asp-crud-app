using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IGDB.Migrations
{
    public partial class modifyPubDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Headquarters",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Headquarters",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Developers");
        }
    }
}
