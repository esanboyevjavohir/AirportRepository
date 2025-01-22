using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airways.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class bilet2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reys_Aircrafts_AircraftId",
                table: "Reys");

            migrationBuilder.DropForeignKey(
                name: "FK_Reys_Airlines_AirlineId",
                table: "Reys");

            migrationBuilder.AlterColumn<Guid>(
                name: "AirlineId",
                table: "Reys",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "AircraftId",
                table: "Reys",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Reys_Aircrafts_AircraftId",
                table: "Reys",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reys_Airlines_AirlineId",
                table: "Reys",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reys_Aircrafts_AircraftId",
                table: "Reys");

            migrationBuilder.DropForeignKey(
                name: "FK_Reys_Airlines_AirlineId",
                table: "Reys");

            migrationBuilder.AlterColumn<Guid>(
                name: "AirlineId",
                table: "Reys",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AircraftId",
                table: "Reys",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reys_Aircrafts_AircraftId",
                table: "Reys",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reys_Airlines_AirlineId",
                table: "Reys",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
