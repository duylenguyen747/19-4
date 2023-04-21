using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BongDa.Migrations
{
    public partial class intit33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pitchs",
                newName: "NamePitch");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingPitch",
                columns: table => new
                {
                    PitchId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingPitch", x => new { x.PitchId, x.BookingId });
                    table.ForeignKey(
                        name: "FK_BookingPitch_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingPitch_Pitchs_PitchId",
                        column: x => x.PitchId,
                        principalTable: "Pitchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingPitch_BookingId",
                table: "BookingPitch",
                column: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingPitch");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.RenameColumn(
                name: "NamePitch",
                table: "Pitchs",
                newName: "Name");
        }
    }
}
