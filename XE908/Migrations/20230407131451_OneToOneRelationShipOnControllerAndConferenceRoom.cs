using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XE908.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneRelationShipOnControllerAndConferenceRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceRooms_Controllers_ControllerHostName",
                table: "ConferenceRooms");

            migrationBuilder.DropIndex(
                name: "IX_ConferenceRooms_ControllerHostName",
                table: "ConferenceRooms");

            migrationBuilder.RenameColumn(
                name: "ControllerHostName",
                table: "ConferenceRooms",
                newName: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceRooms_ControllerId",
                table: "ConferenceRooms",
                column: "ControllerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceRooms_Controllers_ControllerId",
                table: "ConferenceRooms",
                column: "ControllerId",
                principalTable: "Controllers",
                principalColumn: "HostName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceRooms_Controllers_ControllerId",
                table: "ConferenceRooms");

            migrationBuilder.DropIndex(
                name: "IX_ConferenceRooms_ControllerId",
                table: "ConferenceRooms");

            migrationBuilder.RenameColumn(
                name: "ControllerId",
                table: "ConferenceRooms",
                newName: "ControllerHostName");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceRooms_ControllerHostName",
                table: "ConferenceRooms",
                column: "ControllerHostName");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceRooms_Controllers_ControllerHostName",
                table: "ConferenceRooms",
                column: "ControllerHostName",
                principalTable: "Controllers",
                principalColumn: "HostName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
