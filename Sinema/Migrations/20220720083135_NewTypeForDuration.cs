using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sinema.Migrations
{
    public partial class NewTypeForDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "duration",
                table: "Film",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "duration",
                table: "Film",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);
        }
    }
}
