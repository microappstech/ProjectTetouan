using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CptVille.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Section_SectionId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_SectionId",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Blog",
                newName: "TypeBlog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeBlog",
                table: "Blog",
                newName: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_SectionId",
                table: "Blog",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Section_SectionId",
                table: "Blog",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id");
        }
    }
}
