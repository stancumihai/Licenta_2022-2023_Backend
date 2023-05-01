using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAtcolumnonLikedMovieandSeenMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("012d80b3-00c6-4efe-9e2c-96fce52c7c5f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("49bb5071-dda4-4050-ad08-3312e7326d6f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("5544eb12-05ee-4f7c-98cd-f72ed834fa60"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("95b8f7c0-b278-455b-a914-13823eec818d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("9a722784-7221-4f1f-abf7-80aa4b8b4308"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a0df9ccf-5c51-41a9-891e-cfa85233a7d9"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("b219b020-c745-4e00-84d3-e067041590b8"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("ba0d91ba-1180-4df4-827b-2bc132f438ec"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("bfb00e63-85b3-47b1-8fb4-984b092e5b91"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("bfc7e9c9-78a0-43ce-aba1-1ba5eda79365"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("bfc90c46-f863-4c10-9580-ca5163dc5d41"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c66bd3bd-b854-4bee-b14e-a4539bccc63d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("ca4840fa-c691-4324-93f4-3dbd2097841d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("cad50d3c-aad3-4fb5-9207-ae95ede0bf0a"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("cf996b99-4596-4404-aef4-e0947e9faf22"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("d7756a9c-a8c0-425f-b384-2f0d20ff81b0"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("0c4d8a6b-bda2-4f66-8b34-8a477537e7ad"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("3e36b5f4-a9ab-4669-9560-bc636cfb0c86"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("7fdc7f40-bb82-4379-8cdc-8b1a51f0d0d4"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("aee22e43-27b7-40e5-a1ac-c0ff686d05fb"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("bf88bdaa-4ddb-4072-afdc-523028723d4b"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("0c4d8a6b-bda2-4f66-8b34-8a477537e7ad"), 1, "3.Who is your favourite actor?" },
                    { new Guid("3e36b5f4-a9ab-4669-9560-bc636cfb0c86"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("7fdc7f40-bb82-4379-8cdc-8b1a51f0d0d4"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("aee22e43-27b7-40e5-a1ac-c0ff686d05fb"), 2, "4.Who is your favourite director?" },
                    { new Guid("bf88bdaa-4ddb-4072-afdc-523028723d4b"), 3, "1.How frequently do you watch movies?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("012d80b3-00c6-4efe-9e2c-96fce52c7c5f"), new Guid("bf88bdaa-4ddb-4072-afdc-523028723d4b"), "Extremely often" },
                    { new Guid("49bb5071-dda4-4050-ad08-3312e7326d6f"), new Guid("bf88bdaa-4ddb-4072-afdc-523028723d4b"), "Not at all often" },
                    { new Guid("5544eb12-05ee-4f7c-98cd-f72ed834fa60"), new Guid("7fdc7f40-bb82-4379-8cdc-8b1a51f0d0d4"), "Musical" },
                    { new Guid("95b8f7c0-b278-455b-a914-13823eec818d"), new Guid("7fdc7f40-bb82-4379-8cdc-8b1a51f0d0d4"), "Drama" },
                    { new Guid("9a722784-7221-4f1f-abf7-80aa4b8b4308"), new Guid("3e36b5f4-a9ab-4669-9560-bc636cfb0c86"), "" },
                    { new Guid("a0df9ccf-5c51-41a9-891e-cfa85233a7d9"), new Guid("0c4d8a6b-bda2-4f66-8b34-8a477537e7ad"), "" },
                    { new Guid("b219b020-c745-4e00-84d3-e067041590b8"), new Guid("bf88bdaa-4ddb-4072-afdc-523028723d4b"), "Slightly often" },
                    { new Guid("ba0d91ba-1180-4df4-827b-2bc132f438ec"), new Guid("bf88bdaa-4ddb-4072-afdc-523028723d4b"), "Moderately often" },
                    { new Guid("bfb00e63-85b3-47b1-8fb4-984b092e5b91"), new Guid("7fdc7f40-bb82-4379-8cdc-8b1a51f0d0d4"), "Action/Adventure" },
                    { new Guid("bfc7e9c9-78a0-43ce-aba1-1ba5eda79365"), new Guid("7fdc7f40-bb82-4379-8cdc-8b1a51f0d0d4"), "Romance" },
                    { new Guid("bfc90c46-f863-4c10-9580-ca5163dc5d41"), new Guid("7fdc7f40-bb82-4379-8cdc-8b1a51f0d0d4"), "Science-Fiction" },
                    { new Guid("c66bd3bd-b854-4bee-b14e-a4539bccc63d"), new Guid("7fdc7f40-bb82-4379-8cdc-8b1a51f0d0d4"), "Thriller" },
                    { new Guid("ca4840fa-c691-4324-93f4-3dbd2097841d"), new Guid("7fdc7f40-bb82-4379-8cdc-8b1a51f0d0d4"), "Horror" },
                    { new Guid("cad50d3c-aad3-4fb5-9207-ae95ede0bf0a"), new Guid("7fdc7f40-bb82-4379-8cdc-8b1a51f0d0d4"), "Comedy" },
                    { new Guid("cf996b99-4596-4404-aef4-e0947e9faf22"), new Guid("bf88bdaa-4ddb-4072-afdc-523028723d4b"), "Very often" },
                    { new Guid("d7756a9c-a8c0-425f-b384-2f0d20ff81b0"), new Guid("aee22e43-27b7-40e5-a1ac-c0ff686d05fb"), "" }
                });
        }
    }
}
