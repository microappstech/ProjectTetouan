using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CptVille.Migrations
{
    public partial class AddtypePageandsect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "DynamicView",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "DynamicView");
        }
    }
}
