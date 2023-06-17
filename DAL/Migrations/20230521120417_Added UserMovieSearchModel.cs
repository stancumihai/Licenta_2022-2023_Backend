using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserMovieSearchModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AlgorithmName",
                table: "AlgorithmChanges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserMovieSearches",
                columns: table => new
                {
                    UserMovieSearchGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieSearches", x => x.UserMovieSearchGUID);
                    table.ForeignKey(
                        name: "FK_UserMovieSearches_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovieSearches_Movies_MovieGUID",
                        column: x => x.MovieGUID,
                        principalTable: "Movies",
                        principalColumn: "MovieGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieSearches_MovieGUID",
                table: "UserMovieSearches",
                column: "MovieGUID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieSearches_UserGUID",
                table: "UserMovieSearches",
                column: "UserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMovieSearches");

            migrationBuilder.AlterColumn<string>(
                name: "AlgorithmName",
                table: "AlgorithmChanges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
