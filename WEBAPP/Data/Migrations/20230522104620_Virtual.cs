using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WEBAPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class Virtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtime_movies_movieid",
                table: "Showtime");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtime_theaters_theaterid",
                table: "Showtime");

            migrationBuilder.RenameTable(
                name: "Showtime",
                newName: "showtimes");

            migrationBuilder.AlterColumn<int>(
                name: "theaterid",
                table: "showtimes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "movieid",
                table: "showtimes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "showtimeid",
                table: "showtimes",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "endtime",
                table: "showtimes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "showtimes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "starttime",
                table: "showtimes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_showtimes",
                table: "showtimes",
                column: "showtimeid");

            migrationBuilder.CreateIndex(
                name: "IX_showtimes_movieid",
                table: "showtimes",
                column: "movieid");

            migrationBuilder.CreateIndex(
                name: "IX_showtimes_theaterid",
                table: "showtimes",
                column: "theaterid");

            migrationBuilder.AddForeignKey(
                name: "FK_showtimes_movies_movieid",
                table: "showtimes",
                column: "movieid",
                principalTable: "movies",
                principalColumn: "movieid",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_showtimes_movies_movieid",
                table: "showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_showtimes_theaters_theaterid",
                table: "showtimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_showtimes",
                table: "showtimes");

            migrationBuilder.DropIndex(
                name: "IX_showtimes_movieid",
                table: "showtimes");

            migrationBuilder.DropIndex(
                name: "IX_showtimes_theaterid",
                table: "showtimes");

            migrationBuilder.DropColumn(
                name: "showtimeid",
                table: "showtimes");

            migrationBuilder.DropColumn(
                name: "endtime",
                table: "showtimes");

            migrationBuilder.DropColumn(
                name: "price",
                table: "showtimes");

            migrationBuilder.DropColumn(
                name: "starttime",
                table: "showtimes");

            migrationBuilder.RenameTable(
                name: "showtimes",
                newName: "Showtime");

            migrationBuilder.AlterColumn<int>(
                name: "theaterid",
                table: "Showtime",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "movieid",
                table: "Showtime",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtime_movies_movieid",
                table: "Showtime",
                column: "movieid",
                principalTable: "movies",
                principalColumn: "movieid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showtime_theaters_theaterid",
                table: "Showtime",
                column: "theaterid",
                principalTable: "theaters",
                principalColumn: "theaterid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
