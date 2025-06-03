using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksApi.Entities.Migrations
{
    /// <inheritdoc />
    public partial class adduseridinbooktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BookDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_UserId",
                table: "BookDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Users_UserId",
                table: "BookDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Users_UserId",
                table: "BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookDetails_UserId",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookDetails");
        }
    }
}
