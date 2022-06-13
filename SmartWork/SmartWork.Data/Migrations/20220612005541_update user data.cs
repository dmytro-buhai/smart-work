using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartWork.Data.Migrations
{
    public partial class updateuserdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribes_Offices_OfficeId",
                table: "Subscribes");

            migrationBuilder.DropIndex(
                name: "IX_Subscribes_OfficeId",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "DisplayName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Subscribes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_OfficeId",
                table: "Subscribes",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribes_Offices_OfficeId",
                table: "Subscribes",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
