using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAtcolumnonLikedMovieandSeenMovie2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("0e0a6b00-9002-4eef-a0a7-969ea1dbcdde"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("1d478745-cef1-49ce-83ac-8fe4dd8fcea4"), 1, "3.Who is your favourite actor?" },
                    { new Guid("26464da6-930d-493b-82e4-030f3a5035f3"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("3722ebe6-3f27-43e5-b6ca-b2f3f94f43fa"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("42ea3b4a-db75-469b-bab7-cd8f96698048"), 2, "4.Who is your favourite director?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("2bd91d64-2b24-4e38-8869-4eb88635f18f"), new Guid("26464da6-930d-493b-82e4-030f3a5035f3"), "Drama" },
                    { new Guid("519d1d5d-2ec4-4c72-bff0-c693fc411666"), new Guid("26464da6-930d-493b-82e4-030f3a5035f3"), "Science-Fiction" },
                    { new Guid("5a7f005d-22ca-4b35-8a43-2c66801cb5ec"), new Guid("3722ebe6-3f27-43e5-b6ca-b2f3f94f43fa"), "Not at all often" },
                    { new Guid("69dfb657-7a56-48b7-a879-df758bdcece4"), new Guid("1d478745-cef1-49ce-83ac-8fe4dd8fcea4"), "" },
                    { new Guid("700c0605-f19a-4300-8976-e38cc74c9074"), new Guid("0e0a6b00-9002-4eef-a0a7-969ea1dbcdde"), "" },
                    { new Guid("70c047c5-f2a8-4abc-bdd2-0d6d50c61fd4"), new Guid("26464da6-930d-493b-82e4-030f3a5035f3"), "Horror" },
                    { new Guid("780612d2-dcb1-4725-85c2-d8cc134e5790"), new Guid("26464da6-930d-493b-82e4-030f3a5035f3"), "Romance" },
                    { new Guid("852c51c6-5db1-4820-a53f-9e2a4d5a781e"), new Guid("3722ebe6-3f27-43e5-b6ca-b2f3f94f43fa"), "Moderately often" },
                    { new Guid("8bf93ca6-85cc-49cd-9e94-0b3d43953089"), new Guid("3722ebe6-3f27-43e5-b6ca-b2f3f94f43fa"), "Extremely often" },
                    { new Guid("8fb53522-611e-40cc-986e-fb74bccc2837"), new Guid("3722ebe6-3f27-43e5-b6ca-b2f3f94f43fa"), "Very often" },
                    { new Guid("91f22b98-9024-48a9-8361-40640910632f"), new Guid("42ea3b4a-db75-469b-bab7-cd8f96698048"), "" },
                    { new Guid("9f37a95c-bb5b-4257-8f3c-1df6a46c81f4"), new Guid("26464da6-930d-493b-82e4-030f3a5035f3"), "Musical" },
                    { new Guid("b6bdfffa-28bd-4fb9-88e5-9eb3dc0e6ed6"), new Guid("26464da6-930d-493b-82e4-030f3a5035f3"), "Thriller" },
                    { new Guid("c76210f6-136f-4d4a-893c-dccc2252deba"), new Guid("3722ebe6-3f27-43e5-b6ca-b2f3f94f43fa"), "Slightly often" },
                    { new Guid("cf0efb96-db93-4d44-bf3d-dbf0323ea1a3"), new Guid("26464da6-930d-493b-82e4-030f3a5035f3"), "Comedy" },
                    { new Guid("f1e6f858-3b2a-4ff3-b7c3-71af0cd60962"), new Guid("26464da6-930d-493b-82e4-030f3a5035f3"), "Action/Adventure" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("2bd91d64-2b24-4e38-8869-4eb88635f18f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("519d1d5d-2ec4-4c72-bff0-c693fc411666"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("5a7f005d-22ca-4b35-8a43-2c66801cb5ec"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("69dfb657-7a56-48b7-a879-df758bdcece4"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("700c0605-f19a-4300-8976-e38cc74c9074"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("70c047c5-f2a8-4abc-bdd2-0d6d50c61fd4"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("780612d2-dcb1-4725-85c2-d8cc134e5790"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("852c51c6-5db1-4820-a53f-9e2a4d5a781e"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("8bf93ca6-85cc-49cd-9e94-0b3d43953089"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("8fb53522-611e-40cc-986e-fb74bccc2837"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("91f22b98-9024-48a9-8361-40640910632f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("9f37a95c-bb5b-4257-8f3c-1df6a46c81f4"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("b6bdfffa-28bd-4fb9-88e5-9eb3dc0e6ed6"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c76210f6-136f-4d4a-893c-dccc2252deba"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("cf0efb96-db93-4d44-bf3d-dbf0323ea1a3"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("f1e6f858-3b2a-4ff3-b7c3-71af0cd60962"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("0e0a6b00-9002-4eef-a0a7-969ea1dbcdde"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("1d478745-cef1-49ce-83ac-8fe4dd8fcea4"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("26464da6-930d-493b-82e4-030f3a5035f3"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("3722ebe6-3f27-43e5-b6ca-b2f3f94f43fa"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("42ea3b4a-db75-469b-bab7-cd8f96698048"));
        }
    }
}
