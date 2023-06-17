using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedMLModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PredictedGenres",
                columns: table => new
                {
                    PredictedGenreGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictedGenres", x => x.PredictedGenreGUID);
                    table.ForeignKey(
                        name: "FK_PredictedGenres_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PredictedMoviesCount",
                columns: table => new
                {
                    PredictedMovieCountGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieCount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictedMoviesCount", x => x.PredictedMovieCountGUID);
                    table.ForeignKey(
                        name: "FK_PredictedMoviesCount_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PredictedMoviesRuntime",
                columns: table => new
                {
                    PredictedMovieRuntimeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieRuntime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictedMoviesRuntime", x => x.PredictedMovieRuntimeGUID);
                    table.ForeignKey(
                        name: "FK_PredictedMoviesRuntime_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredictedGenres_UserGUID",
                table: "PredictedGenres",
                column: "UserGUID");

            migrationBuilder.CreateIndex(
                name: "IX_PredictedMoviesCount_UserGUID",
                table: "PredictedMoviesCount",
                column: "UserGUID");

            migrationBuilder.CreateIndex(
                name: "IX_PredictedMoviesRuntime_UserGUID",
                table: "PredictedMoviesRuntime",
                column: "UserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredictedGenres");

            migrationBuilder.DropTable(
                name: "PredictedMoviesCount");

            migrationBuilder.DropTable(
                name: "PredictedMoviesRuntime");
        }
    }
}
