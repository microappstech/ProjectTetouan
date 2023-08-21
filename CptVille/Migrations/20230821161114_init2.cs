using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CptVille.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Section_SectionId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "MainSectionId",
                table: "Blog");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Blog",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Section_SectionId",
                table: "Blog",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id"
                //onDelete: ReferentialAction.Cascade
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Section_SectionId",
                table: "Blog");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Blog",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MainSectionId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Section_SectionId",
                table: "Blog",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id");
        }
    }
}
