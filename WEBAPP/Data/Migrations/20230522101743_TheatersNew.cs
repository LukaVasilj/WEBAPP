using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WEBAPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class TheatersNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_showtimes_Theater_theaterid",
                table: "showtimes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Theater_TempId",
                table: "Theater");

            migrationBuilder.RenameTable(
                name: "Theater",
                newName: "theaters");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "theaters",
                newName: "capacity");

            migrationBuilder.AddColumn<int>(
                name: "theaterid",
                table: "theaters",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "theaters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_theaters",
                table: "theaters",
                column: "theaterid");

            migrationBuilder.AddForeignKey(
                name: "FK_showtimes_theaters_theaterid",
                table: "showtimes",
                column: "theaterid",
                principalTable: "theaters",
                principalColumn: "theaterid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_showtimes_theaters_theaterid",
                table: "showtimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_theaters",
                table: "theaters");

            migrationBuilder.DropColumn(
                name: "theaterid",
                table: "theaters");

            migrationBuilder.DropColumn(
                name: "name",
                table: "theaters");

            migrationBuilder.RenameTable(
                name: "theaters",
                newName: "Theater");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Theater",
                newName: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Theater_TempId",
                table: "Theater",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_showtimes_Theater_theaterid",
                table: "showtimes",
                column: "theaterid",
                principalTable: "Theater",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
