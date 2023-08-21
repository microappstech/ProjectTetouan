using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CptVille.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_UnderSection_UnderSectionId",
                table: "Blog");

            migrationBuilder.AlterColumn<int>(
                name: "UnderSectionId",
                table: "Blog",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_UnderSection_UnderSectionId",
                table: "Blog",
                column: "UnderSectionId",
                principalTable: "UnderSection",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_UnderSection_UnderSectionId",
                table: "Blog");

            migrationBuilder.AlterColumn<int>(
                name: "UnderSectionId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_UnderSection_UnderSectionId",
                table: "Blog",
                column: "UnderSectionId",
                principalTable: "UnderSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
