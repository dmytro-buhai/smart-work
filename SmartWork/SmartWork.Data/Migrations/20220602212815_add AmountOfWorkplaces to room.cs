using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartWork.Data.Migrations
{
    public partial class addAmountOfWorkplacestoroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfWorkplaces",
                table: "Rooms",
                type: "int",
                maxLength: 1024,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_RoomId",
                table: "Statistics",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Rooms_RoomId",
                table: "Statistics",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Rooms_RoomId",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_RoomId",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "AmountOfWorkplaces",
                table: "Rooms");
        }
    }
}
