using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IGDB.Migrations
{
    public partial class AddCoverImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImg",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImg",
                table: "Games");
        }
    }
}
