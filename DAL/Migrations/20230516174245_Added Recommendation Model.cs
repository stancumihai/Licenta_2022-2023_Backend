using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedRecommendationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("1f4445a7-2f61-4fdb-ad3e-11200ab86fe6"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("1fcd035d-2829-49b6-98d2-2a55cdae7f8e"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("3e0221ff-0393-4551-9364-d1264cee01a3"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("3f98b174-938c-4deb-8f24-2b9f43d48df1"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("565504f1-38e3-4ef0-a912-ceca8be70d0d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("578d40dc-8ba0-4818-acbb-0684bc83ee41"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("5d5882a5-d776-420d-942b-040ae57c8e2f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("603d2b8e-2eca-4b57-8661-3aad88f97e14"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("77f9680c-9aec-41d8-8ddb-f3968cd8572f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("857ad7a0-a1a8-4a78-ae27-a4d730b222e3"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("aa450a6b-1124-4bf2-9a9e-c9ab8ba1b36d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c21947ef-7aeb-45a4-96a2-fece5ea049c2"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c967969e-edf3-4f74-9d97-0bccccf7e4a6"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("df7e1920-9c09-40ec-a7dd-335852af3fd7"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("e9033eb2-e819-4925-b444-03903c321b0d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("ed555395-cad6-48c4-a373-4e90fbb002e4"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("6cd8b00a-ea46-44e5-ada7-0bf73664124a"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("aa48b009-e940-4e88-a423-d967ccdee3d9"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("b722b6fa-9c10-432a-a153-e8dd23367ebd"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("d4d65821-0366-4955-9fbe-03a754410860"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("e17b45f1-03e3-45a0-ae5d-1f78c9f6d73a"));

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    RecommendationGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LikedDecisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLiked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.RecommendationGUID);
                    table.ForeignKey(
                        name: "FK_Recommendations_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recommendations_Movies_MovieGUID",
                        column: x => x.MovieGUID,
                        principalTable: "Movies",
                        principalColumn: "MovieGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_MovieGUID",
                table: "Recommendations",
                column: "MovieGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_UserGUID",
                table: "Recommendations",
                column: "UserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("6cd8b00a-ea46-44e5-ada7-0bf73664124a"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("aa48b009-e940-4e88-a423-d967ccdee3d9"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("b722b6fa-9c10-432a-a153-e8dd23367ebd"), 2, "4.Who is your favourite director?" },
                    { new Guid("d4d65821-0366-4955-9fbe-03a754410860"), 1, "3.Who is your favourite actor?" },
                    { new Guid("e17b45f1-03e3-45a0-ae5d-1f78c9f6d73a"), 3, "1.How frequently do you watch movies?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("1f4445a7-2f61-4fdb-ad3e-11200ab86fe6"), new Guid("6cd8b00a-ea46-44e5-ada7-0bf73664124a"), "Thriller" },
                    { new Guid("1fcd035d-2829-49b6-98d2-2a55cdae7f8e"), new Guid("6cd8b00a-ea46-44e5-ada7-0bf73664124a"), "Comedy" },
                    { new Guid("3e0221ff-0393-4551-9364-d1264cee01a3"), new Guid("e17b45f1-03e3-45a0-ae5d-1f78c9f6d73a"), "Not at all often" },
                    { new Guid("3f98b174-938c-4deb-8f24-2b9f43d48df1"), new Guid("6cd8b00a-ea46-44e5-ada7-0bf73664124a"), "Action/Adventure" },
                    { new Guid("565504f1-38e3-4ef0-a912-ceca8be70d0d"), new Guid("6cd8b00a-ea46-44e5-ada7-0bf73664124a"), "Romance" },
                    { new Guid("578d40dc-8ba0-4818-acbb-0684bc83ee41"), new Guid("e17b45f1-03e3-45a0-ae5d-1f78c9f6d73a"), "Moderately often" },
                    { new Guid("5d5882a5-d776-420d-942b-040ae57c8e2f"), new Guid("e17b45f1-03e3-45a0-ae5d-1f78c9f6d73a"), "Extremely often" },
                    { new Guid("603d2b8e-2eca-4b57-8661-3aad88f97e14"), new Guid("b722b6fa-9c10-432a-a153-e8dd23367ebd"), "" },
                    { new Guid("77f9680c-9aec-41d8-8ddb-f3968cd8572f"), new Guid("6cd8b00a-ea46-44e5-ada7-0bf73664124a"), "Horror" },
                    { new Guid("857ad7a0-a1a8-4a78-ae27-a4d730b222e3"), new Guid("aa48b009-e940-4e88-a423-d967ccdee3d9"), "" },
                    { new Guid("aa450a6b-1124-4bf2-9a9e-c9ab8ba1b36d"), new Guid("6cd8b00a-ea46-44e5-ada7-0bf73664124a"), "Science-Fiction" },
                    { new Guid("c21947ef-7aeb-45a4-96a2-fece5ea049c2"), new Guid("6cd8b00a-ea46-44e5-ada7-0bf73664124a"), "Musical" },
                    { new Guid("c967969e-edf3-4f74-9d97-0bccccf7e4a6"), new Guid("6cd8b00a-ea46-44e5-ada7-0bf73664124a"), "Drama" },
                    { new Guid("df7e1920-9c09-40ec-a7dd-335852af3fd7"), new Guid("d4d65821-0366-4955-9fbe-03a754410860"), "" },
                    { new Guid("e9033eb2-e819-4925-b444-03903c321b0d"), new Guid("e17b45f1-03e3-45a0-ae5d-1f78c9f6d73a"), "Very often" },
                    { new Guid("ed555395-cad6-48c4-a373-4e90fbb002e4"), new Guid("e17b45f1-03e3-45a0-ae5d-1f78c9f6d73a"), "Slightly often" }
                });
        }
    }
}
