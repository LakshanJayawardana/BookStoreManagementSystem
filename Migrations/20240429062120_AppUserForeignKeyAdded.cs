using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AppUserForeignKeyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Books",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AppUserId",
                table: "Books",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_AppUserId",
                table: "Books",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_AppUserId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AppUserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Books");
        }
    }
}
