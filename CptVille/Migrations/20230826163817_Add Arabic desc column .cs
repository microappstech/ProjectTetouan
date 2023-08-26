using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CptVille.Migrations
{
    public partial class AddArabicdesccolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "arabic_description",
                table: "Parameters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "arabic_description",
                table: "Parameters");
        }
    }
}
