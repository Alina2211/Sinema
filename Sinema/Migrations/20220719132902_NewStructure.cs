using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sinema.Migrations
{
    public partial class NewStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "place",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "rowNumber",
                table: "Ticket");

            migrationBuilder.AddColumn<long>(
                name: "placeId",
                table: "Ticket",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "hallId",
                table: "Schedule",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "duration",
                table: "Film",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hall",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hallName = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hall", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rowNumber = table.Column<int>(type: "integer", nullable: false),
                    placeNumber = table.Column<int>(type: "integer", nullable: false),
                    cost = table.Column<int>(type: "integer", nullable: false),
                    availability = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceHall",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    placeId = table.Column<long>(type: "bigint", nullable: false),
                    hallId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceHall", x => x.id);
                    table.ForeignKey(
                        name: "PlaceHallHall_fk",
                        column: x => x.hallId,
                        principalTable: "Hall",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PlaceHallPlace_fk",
                        column: x => x.placeId,
                        principalTable: "Place",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_placeId",
                table: "Ticket",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_hallId",
                table: "Schedule",
                column: "hallId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceHall_hallId",
                table: "PlaceHall",
                column: "hallId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceHall_placeId",
                table: "PlaceHall",
                column: "placeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "ScheduleHall_fk",
                table: "Schedule",
                column: "hallId",
                principalTable: "Hall",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "TicketPlace_fk",
                table: "Ticket",
                column: "placeId",
                principalTable: "Place",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ScheduleHall_fk",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "TicketPlace_fk",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "PlaceHall");

            migrationBuilder.DropTable(
                name: "Hall");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_placeId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_hallId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "placeId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "hallId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "duration",
                table: "Film");

            migrationBuilder.AddColumn<int>(
                name: "place",
                table: "Ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rowNumber",
                table: "Ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
