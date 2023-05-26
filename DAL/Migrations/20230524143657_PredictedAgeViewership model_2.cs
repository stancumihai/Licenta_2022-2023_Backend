using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class PredictedAgeViewershipmodel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PredictedAgeGUID",
                table: "PredictedAgeViewerships",
                newName: "PredictedAgeViewershipGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PredictedAgeViewershipGUID",
                table: "PredictedAgeViewerships",
                newName: "PredictedAgeGUID");
        }
    }
}
