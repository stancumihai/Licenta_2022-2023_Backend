using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Nush : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("2e2a05a8-c1ae-4762-b159-9485e32e3ab5"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("560dfb8d-188d-43bd-9ff0-7324912274ce"), 1, "3.Who is your favourite actor?" },
                    { new Guid("63a9203e-b1fa-463e-a6d8-69076908761d"), 2, "4.Who is your favourite director?" },
                    { new Guid("6fecf9c5-a384-4eb5-85fd-a4d96a0610eb"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("e9b8ff68-c4f0-4e10-8a02-2ac27db2f715"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("022faf3f-3dd9-4ec0-9a58-be582ff850d4"), new Guid("6fecf9c5-a384-4eb5-85fd-a4d96a0610eb"), "Action/Adventure" },
                    { new Guid("083016dd-c920-4c01-8f8a-900e8d0d9dff"), new Guid("2e2a05a8-c1ae-4762-b159-9485e32e3ab5"), "Not at all often" },
                    { new Guid("10c709c7-5223-44d2-a1d2-8ed044e94cd4"), new Guid("2e2a05a8-c1ae-4762-b159-9485e32e3ab5"), "Slightly often" },
                    { new Guid("1fbd14e1-e74d-43d5-8b1e-5dcee0d023ce"), new Guid("e9b8ff68-c4f0-4e10-8a02-2ac27db2f715"), "" },
                    { new Guid("2a509eeb-bd6e-46cf-b350-6ea913980376"), new Guid("6fecf9c5-a384-4eb5-85fd-a4d96a0610eb"), "Musical" },
                    { new Guid("39b5953d-0bac-4417-a43d-0ad193cd33aa"), new Guid("6fecf9c5-a384-4eb5-85fd-a4d96a0610eb"), "Romance" },
                    { new Guid("6b1571be-d1f4-4535-88a0-92e23f6dd88f"), new Guid("2e2a05a8-c1ae-4762-b159-9485e32e3ab5"), "Moderately often" },
                    { new Guid("8d55c0e9-efd8-46a6-8ed6-7f81f9aa8d30"), new Guid("6fecf9c5-a384-4eb5-85fd-a4d96a0610eb"), "Horror" },
                    { new Guid("a27b3bb0-e4de-4919-9bf5-e026443cf392"), new Guid("63a9203e-b1fa-463e-a6d8-69076908761d"), "" },
                    { new Guid("b2c6a70f-2fe9-4df5-a268-ad1d07daaff4"), new Guid("6fecf9c5-a384-4eb5-85fd-a4d96a0610eb"), "Thriller" },
                    { new Guid("c032531e-7d3a-4459-8fe9-f5d053ed8326"), new Guid("2e2a05a8-c1ae-4762-b159-9485e32e3ab5"), "Very often" },
                    { new Guid("cc7426ad-b364-499a-bf1a-633c23847629"), new Guid("6fecf9c5-a384-4eb5-85fd-a4d96a0610eb"), "Science-Fiction" },
                    { new Guid("cf5d9fc7-e611-488d-abe1-7819fe2c47ec"), new Guid("6fecf9c5-a384-4eb5-85fd-a4d96a0610eb"), "Comedy" },
                    { new Guid("ed8f14b0-3453-4bae-a19a-cf7136200a38"), new Guid("2e2a05a8-c1ae-4762-b159-9485e32e3ab5"), "Extremely often" },
                    { new Guid("f2bc4631-d469-432c-b626-b1ed77ff097a"), new Guid("560dfb8d-188d-43bd-9ff0-7324912274ce"), "" },
                    { new Guid("fc5b3f87-bb76-43b0-83ff-caa6dbd1c7a7"), new Guid("6fecf9c5-a384-4eb5-85fd-a4d96a0610eb"), "Drama" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("022faf3f-3dd9-4ec0-9a58-be582ff850d4"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("083016dd-c920-4c01-8f8a-900e8d0d9dff"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("10c709c7-5223-44d2-a1d2-8ed044e94cd4"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("1fbd14e1-e74d-43d5-8b1e-5dcee0d023ce"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("2a509eeb-bd6e-46cf-b350-6ea913980376"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("39b5953d-0bac-4417-a43d-0ad193cd33aa"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("6b1571be-d1f4-4535-88a0-92e23f6dd88f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("8d55c0e9-efd8-46a6-8ed6-7f81f9aa8d30"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a27b3bb0-e4de-4919-9bf5-e026443cf392"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("b2c6a70f-2fe9-4df5-a268-ad1d07daaff4"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c032531e-7d3a-4459-8fe9-f5d053ed8326"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("cc7426ad-b364-499a-bf1a-633c23847629"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("cf5d9fc7-e611-488d-abe1-7819fe2c47ec"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("ed8f14b0-3453-4bae-a19a-cf7136200a38"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("f2bc4631-d469-432c-b626-b1ed77ff097a"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("fc5b3f87-bb76-43b0-83ff-caa6dbd1c7a7"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("2e2a05a8-c1ae-4762-b159-9485e32e3ab5"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("560dfb8d-188d-43bd-9ff0-7324912274ce"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("63a9203e-b1fa-463e-a6d8-69076908761d"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("6fecf9c5-a384-4eb5-85fd-a4d96a0610eb"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("e9b8ff68-c4f0-4e10-8a02-2ac27db2f715"));
        }
    }
}
