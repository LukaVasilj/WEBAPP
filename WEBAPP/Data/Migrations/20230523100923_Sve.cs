using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WEBAPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class Sve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    movieid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    releasedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    genreid = table.Column<int>(type: "integer", nullable: false),
                    director = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.movieid);
                });

            migrationBuilder.CreateTable(
                name: "theaters",
                columns: table => new
                {
                    theaterid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theaters", x => x.theaterid);
                });

            migrationBuilder.CreateTable(
                name: "showtimes",
                columns: table => new
                {
                    showtimeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    theaterid = table.Column<int>(type: "integer", nullable: false),
                    movieid = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    starttime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    endtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_showtimes", x => x.showtimeid);
                    table.ForeignKey(
                        name: "FK_showtimes_movies_movieid",
                        column: x => x.movieid,
                        principalTable: "movies",
                        principalColumn: "movieid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_showtimes_theaters_theaterid",
                        column: x => x.theaterid,
                        principalTable: "theaters",
                        principalColumn: "theaterid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_showtimes_movieid",
                table: "showtimes",
                column: "movieid");

            migrationBuilder.CreateIndex(
                name: "IX_showtimes_theaterid",
                table: "showtimes",
                column: "theaterid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "showtimes");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "theaters");
        }
    }
}
