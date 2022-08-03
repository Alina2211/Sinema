using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sinema.Migrations
{
    public partial class TableForPlaceAvailability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "availability",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "cost",
                table: "Place");

            migrationBuilder.CreateTable(
                name: "PlaceSession",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    placeId = table.Column<long>(type: "bigint", nullable: false),
                    scheduleId = table.Column<long>(type: "bigint", nullable: false),
                    cost = table.Column<int>(type: "integer", nullable: false),
                    availability = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceSession", x => x.id);
                    table.ForeignKey(
                        name: "PlaceAvailability_fk",
                        column: x => x.placeId,
                        principalTable: "Place",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SessionAvailability_fk",
                        column: x => x.scheduleId,
                        principalTable: "Schedule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceSession_placeId",
                table: "PlaceSession",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceSession_scheduleId",
                table: "PlaceSession",
                column: "scheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceSession");

            migrationBuilder.AddColumn<bool>(
                name: "availability",
                table: "Place",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "cost",
                table: "Place",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
