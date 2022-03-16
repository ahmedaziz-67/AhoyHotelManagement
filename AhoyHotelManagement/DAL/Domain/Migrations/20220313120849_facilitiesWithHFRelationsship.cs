using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhoyHotelManagement.Migrations
{
    public partial class facilitiesWithHFRelationsship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelFacilities_Facilities_FacilitiyId",
                table: "HotelFacilities");

            migrationBuilder.DropIndex(
                name: "IX_HotelFacilities_FacilitiyId",
                table: "HotelFacilities");

            migrationBuilder.DropColumn(
                name: "FacilitiyId",
                table: "HotelFacilities");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFacilities_FacilityId",
                table: "HotelFacilities",
                column: "FacilityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelFacilities_Facilities_FacilityId",
                table: "HotelFacilities",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelFacilities_Facilities_FacilityId",
                table: "HotelFacilities");

            migrationBuilder.DropIndex(
                name: "IX_HotelFacilities_FacilityId",
                table: "HotelFacilities");

            migrationBuilder.AddColumn<Guid>(
                name: "FacilitiyId",
                table: "HotelFacilities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_HotelFacilities_FacilitiyId",
                table: "HotelFacilities",
                column: "FacilitiyId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelFacilities_Facilities_FacilitiyId",
                table: "HotelFacilities",
                column: "FacilitiyId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
