using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Para.Server.Migrations
{
    public partial class ChangesToStor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserStories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserStories_UserId",
                table: "UserStories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStories_Users_UserId",
                table: "UserStories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStories_Users_UserId",
                table: "UserStories");

            migrationBuilder.DropIndex(
                name: "IX_UserStories_UserId",
                table: "UserStories");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserStories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
