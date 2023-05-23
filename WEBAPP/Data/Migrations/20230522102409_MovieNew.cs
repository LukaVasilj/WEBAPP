using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WEBAPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class MovieNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_showtimes_Movie_movieid",
                table: "showtimes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Movie_TempId",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "movies");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "movies",
                newName: "genreid");

            migrationBuilder.AddColumn<int>(
                name: "movieid",
                table: "movies",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "director",
                table: "movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "releasedate",
                table: "movies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "movies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "movieid");

            migrationBuilder.AddForeignKey(
                name: "FK_showtimes_movies_movieid",
                table: "showtimes",
                column: "movieid",
                principalTable: "movies",
                principalColumn: "movieid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_showtimes_movies_movieid",
                table: "showtimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "movieid",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "description",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "director",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "releasedate",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "title",
                table: "movies");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movie");

            migrationBuilder.RenameColumn(
                name: "genreid",
                table: "Movie",
                newName: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Movie_TempId",
                table: "Movie",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_showtimes_Movie_movieid",
                table: "showtimes",
                column: "movieid",
                principalTable: "Movie",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
