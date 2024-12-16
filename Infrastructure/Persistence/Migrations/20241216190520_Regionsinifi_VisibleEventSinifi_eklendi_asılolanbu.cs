using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Regionsinifi_VisibleEventSinifi_eklendi_asılolanbu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Region_RegionId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.RenameTable(
                name: "Region",
                newName: "Regions");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "RegionId");

            migrationBuilder.CreateTable(
                name: "VisibleEvents",
                columns: table => new
                {
                    VisibleEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisibleEvents", x => x.VisibleEventId);
                });

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
                name: "FK_Users_Regions_RegionId",
                table: "Users",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_VisibleEvents_VisibleEventId",
                table: "Users",
                column: "VisibleEventId",
                principalTable: "VisibleEvents",
                principalColumn: "VisibleEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_VisibleEvents_VisibleEventId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Regions_RegionId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_VisibleEvents_VisibleEventId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "VisibleEvents");

            migrationBuilder.DropIndex(
                name: "IX_Users_VisibleEventId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Events_VisibleEventId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "VisibleEventId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VisibleEventId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Region");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Region_RegionId",
                table: "Users",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "RegionId");
        }
    }
}
