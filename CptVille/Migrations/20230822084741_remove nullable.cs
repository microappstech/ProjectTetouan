using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CptVille.Migrations
{
    public partial class removenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnderSection_Section_MainSectionId",
                table: "UnderSection");

            migrationBuilder.AlterColumn<int>(
                name: "MainSectionId",
                table: "UnderSection",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UnderSection_Section_MainSectionId",
                table: "UnderSection",
                column: "MainSectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnderSection_Section_MainSectionId",
                table: "UnderSection");

            migrationBuilder.AlterColumn<int>(
                name: "MainSectionId",
                table: "UnderSection",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UnderSection_Section_MainSectionId",
                table: "UnderSection",
                column: "MainSectionId",
                principalTable: "Section",
                principalColumn: "Id");
        }
    }
}
