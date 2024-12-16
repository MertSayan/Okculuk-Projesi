using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class düzeltmeyapıldı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_VisibleEvents_VisibleEventId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_VisibleEvents_VisibleEventId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VisibleEventId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Events_VisibleEventId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VisibleEventId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VisibleEventId",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_VisibleEvents_EventId",
                table: "VisibleEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_VisibleEvents_UserId",
                table: "VisibleEvents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisibleEvents_Events_EventId",
                table: "VisibleEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisibleEvents_Users_UserId",
                table: "VisibleEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisibleEvents_Events_EventId",
                table: "VisibleEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_VisibleEvents_Users_UserId",
                table: "VisibleEvents");

            migrationBuilder.DropIndex(
                name: "IX_VisibleEvents_EventId",
                table: "VisibleEvents");

            migrationBuilder.DropIndex(
                name: "IX_VisibleEvents_UserId",
                table: "VisibleEvents");

            migrationBuilder.AddColumn<int>(
                name: "VisibleEventId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisibleEventId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_VisibleEventId",
                table: "Users",
                column: "VisibleEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VisibleEventId",
                table: "Events",
                column: "VisibleEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_VisibleEvents_VisibleEventId",
                table: "Events",
                column: "VisibleEventId",
                principalTable: "VisibleEvents",
                principalColumn: "VisibleEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_VisibleEvents_VisibleEventId",
                table: "Users",
                column: "VisibleEventId",
                principalTable: "VisibleEvents",
                principalColumn: "VisibleEventId");
        }
    }
}
