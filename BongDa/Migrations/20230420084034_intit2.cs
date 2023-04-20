using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BongDa.Migrations
{
    public partial class intit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Pitchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pitchs_UserId",
                table: "Pitchs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pitchs_Users_UserId",
                table: "Pitchs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pitchs_Users_UserId",
                table: "Pitchs");

            migrationBuilder.DropIndex(
                name: "IX_Pitchs_UserId",
                table: "Pitchs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pitchs");
        }
    }
}
