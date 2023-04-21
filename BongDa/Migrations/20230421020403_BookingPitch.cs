using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BongDa.Migrations
{
    public partial class BookingPitch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingPitch_Bookings_BookingId",
                table: "BookingPitch");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingPitch_Pitchs_PitchId",
                table: "BookingPitch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingPitch",
                table: "BookingPitch");

            migrationBuilder.RenameTable(
                name: "BookingPitch",
                newName: "BookingPitches");

            migrationBuilder.RenameIndex(
                name: "IX_BookingPitch_BookingId",
                table: "BookingPitches",
                newName: "IX_BookingPitches_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingPitches",
                table: "BookingPitches",
                columns: new[] { "PitchId", "BookingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPitches_Bookings_BookingId",
                table: "BookingPitches",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPitches_Pitchs_PitchId",
                table: "BookingPitches",
                column: "PitchId",
                principalTable: "Pitchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingPitches_Bookings_BookingId",
                table: "BookingPitches");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingPitches_Pitchs_PitchId",
                table: "BookingPitches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingPitches",
                table: "BookingPitches");

            migrationBuilder.RenameTable(
                name: "BookingPitches",
                newName: "BookingPitch");

            migrationBuilder.RenameIndex(
                name: "IX_BookingPitches_BookingId",
                table: "BookingPitch",
                newName: "IX_BookingPitch_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingPitch",
                table: "BookingPitch",
                columns: new[] { "PitchId", "BookingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPitch_Bookings_BookingId",
                table: "BookingPitch",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPitch_Pitchs_PitchId",
                table: "BookingPitch",
                column: "PitchId",
                principalTable: "Pitchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
