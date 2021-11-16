using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetMovieSearch.Migrations
{
    public partial class fixedGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Genres_GenreId",
                table: "MovieGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Movies_MovieId",
                table: "MovieGenres");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieGenres",
                newName: "MovieIdId");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "MovieGenres",
                newName: "GenreIdId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres",
                newName: "IX_MovieGenres_MovieIdId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres",
                newName: "IX_MovieGenres_GenreIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Genres_GenreIdId",
                table: "MovieGenres",
                column: "GenreIdId",
                principalTable: "Genres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Movies_MovieIdId",
                table: "MovieGenres",
                column: "MovieIdId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Genres_GenreIdId",
                table: "MovieGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Movies_MovieIdId",
                table: "MovieGenres");

            migrationBuilder.RenameColumn(
                name: "MovieIdId",
                table: "MovieGenres",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "GenreIdId",
                table: "MovieGenres",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenres_MovieIdId",
                table: "MovieGenres",
                newName: "IX_MovieGenres_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenres_GenreIdId",
                table: "MovieGenres",
                newName: "IX_MovieGenres_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Genres_GenreId",
                table: "MovieGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Movies_MovieId",
                table: "MovieGenres",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
