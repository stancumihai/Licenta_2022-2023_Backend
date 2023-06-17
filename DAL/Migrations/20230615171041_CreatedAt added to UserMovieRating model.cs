using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAtaddedtoUserMovieRatingmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserMovieRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("2c99bcc9-e553-4e14-86c1-5c53f62bf39b"), 1, "3.Who is your favourite actor?" },
                    { new Guid("985e3b9a-7c16-4f13-b074-3cfe73a22bce"), 2, "4.Who is your favourite director?" },
                    { new Guid("a0c7f5f2-458a-44f1-acd7-c573a20ccffb"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("b9bfcb20-f815-444b-8a91-462a09c39305"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("cc1078e8-d312-4e89-bf56-acf97f11d0c7"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("1b4bc412-ef9b-42db-b9c3-a9acd0a1dad1"), new Guid("a0c7f5f2-458a-44f1-acd7-c573a20ccffb"), "Horror" },
                    { new Guid("473de930-044b-4959-b476-15bf1e4d9fc3"), new Guid("2c99bcc9-e553-4e14-86c1-5c53f62bf39b"), "" },
                    { new Guid("56dfd1d9-df20-425a-9602-0efa9b861b4a"), new Guid("b9bfcb20-f815-444b-8a91-462a09c39305"), "Moderately often" },
                    { new Guid("60dff166-c902-4857-9938-4d899988a84e"), new Guid("a0c7f5f2-458a-44f1-acd7-c573a20ccffb"), "Musical" },
                    { new Guid("62f45269-eda1-4abf-81c4-cb3bdb141ce5"), new Guid("b9bfcb20-f815-444b-8a91-462a09c39305"), "Very often" },
                    { new Guid("76c3f79b-3f75-4d2e-b70f-6ee03b28ce97"), new Guid("985e3b9a-7c16-4f13-b074-3cfe73a22bce"), "" },
                    { new Guid("7ccf03c9-ac7c-4cfc-9480-ecf88d6f175b"), new Guid("a0c7f5f2-458a-44f1-acd7-c573a20ccffb"), "Comedy" },
                    { new Guid("8890577a-e276-47ea-aa6c-dde805f0b8df"), new Guid("b9bfcb20-f815-444b-8a91-462a09c39305"), "Slightly often" },
                    { new Guid("91240bc4-3ad8-452e-8a72-b840268017e7"), new Guid("b9bfcb20-f815-444b-8a91-462a09c39305"), "Not at all often" },
                    { new Guid("91972131-4f05-49aa-a297-da61b1c96895"), new Guid("a0c7f5f2-458a-44f1-acd7-c573a20ccffb"), "Romance" },
                    { new Guid("95981139-a8e4-4a38-a838-5d84037a1e45"), new Guid("a0c7f5f2-458a-44f1-acd7-c573a20ccffb"), "Thriller" },
                    { new Guid("a6bb32f9-0ade-4112-9012-99c040bbf4a3"), new Guid("a0c7f5f2-458a-44f1-acd7-c573a20ccffb"), "Action/Adventure" },
                    { new Guid("baa92775-bbac-46a4-ac44-3220e931e789"), new Guid("a0c7f5f2-458a-44f1-acd7-c573a20ccffb"), "Science-Fiction" },
                    { new Guid("c38548cc-c489-4da4-b352-459a80454f67"), new Guid("cc1078e8-d312-4e89-bf56-acf97f11d0c7"), "" },
                    { new Guid("d3eba87d-9778-41e4-8e63-dfded590c220"), new Guid("b9bfcb20-f815-444b-8a91-462a09c39305"), "Extremely often" },
                    { new Guid("de8b3d1c-9e36-4358-891a-eeb07202a18a"), new Guid("a0c7f5f2-458a-44f1-acd7-c573a20ccffb"), "Drama" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("1b4bc412-ef9b-42db-b9c3-a9acd0a1dad1"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("473de930-044b-4959-b476-15bf1e4d9fc3"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("56dfd1d9-df20-425a-9602-0efa9b861b4a"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("60dff166-c902-4857-9938-4d899988a84e"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("62f45269-eda1-4abf-81c4-cb3bdb141ce5"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("76c3f79b-3f75-4d2e-b70f-6ee03b28ce97"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("7ccf03c9-ac7c-4cfc-9480-ecf88d6f175b"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("8890577a-e276-47ea-aa6c-dde805f0b8df"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("91240bc4-3ad8-452e-8a72-b840268017e7"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("91972131-4f05-49aa-a297-da61b1c96895"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("95981139-a8e4-4a38-a838-5d84037a1e45"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a6bb32f9-0ade-4112-9012-99c040bbf4a3"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("baa92775-bbac-46a4-ac44-3220e931e789"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c38548cc-c489-4da4-b352-459a80454f67"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("d3eba87d-9778-41e4-8e63-dfded590c220"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("de8b3d1c-9e36-4358-891a-eeb07202a18a"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("2c99bcc9-e553-4e14-86c1-5c53f62bf39b"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("985e3b9a-7c16-4f13-b074-3cfe73a22bce"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("a0c7f5f2-458a-44f1-acd7-c573a20ccffb"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("b9bfcb20-f815-444b-8a91-462a09c39305"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("cc1078e8-d312-4e89-bf56-acf97f11d0c7"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserMovieRatings");

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
    }
}
