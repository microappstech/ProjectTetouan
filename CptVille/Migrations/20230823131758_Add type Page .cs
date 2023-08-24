using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CptVille.Migrations
{
    public partial class AddtypePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypePage",
                table: "DynamicView",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypePage",
                table: "DynamicView");
        }
    }
}
