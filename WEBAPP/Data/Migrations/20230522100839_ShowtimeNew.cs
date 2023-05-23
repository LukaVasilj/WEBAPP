using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPP.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShowtimeNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
