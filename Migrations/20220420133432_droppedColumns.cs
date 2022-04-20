using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IGDB.Migrations
{
    public partial class droppedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Developers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
