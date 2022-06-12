using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartWork.Data.Migrations
{
    public partial class updatesubscribe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribes_SubscribeDetails_SubscribeDetailId",
                table: "Subscribes");

            migrationBuilder.RenameColumn(
                name: "SubscribeDetailId",
                table: "Subscribes",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "StartSubscribe",
                table: "Subscribes",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EndSubscribe",
                table: "Subscribes",
                newName: "EndDate");

            migrationBuilder.RenameIndex(
                name: "IX_Subscribes_SubscribeDetailId",
                table: "Subscribes",
                newName: "IX_Subscribes_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribes_Rooms_RoomId",
                table: "Subscribes",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribes_Rooms_RoomId",
                table: "Subscribes");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Subscribes",
                newName: "StartSubscribe");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Subscribes",
                newName: "SubscribeDetailId");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Subscribes",
                newName: "EndSubscribe");

            migrationBuilder.RenameIndex(
                name: "IX_Subscribes_RoomId",
                table: "Subscribes",
                newName: "IX_Subscribes_SubscribeDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribes_SubscribeDetails_SubscribeDetailId",
                table: "Subscribes",
                column: "SubscribeDetailId",
                principalTable: "SubscribeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
