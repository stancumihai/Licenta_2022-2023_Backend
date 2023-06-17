using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAtaddedtoUserMovieRatingmodel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("461f1e2c-ea24-4283-a095-3864526d21b1"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("57937521-fe6b-4680-8c5e-f3ffccc26bdf"), 2, "4.Who is your favourite director?" },
                    { new Guid("8c1be0da-b1ca-45ef-a18a-ddb9c73608a1"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("91a96e1b-49cc-4580-9e94-32d1932c2408"), 1, "3.Who is your favourite actor?" },
                    { new Guid("cbba306f-f67c-4fb6-bb35-d4fb66f5d155"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("10dd42ec-39a9-4c4a-bec6-05311551e391"), new Guid("8c1be0da-b1ca-45ef-a18a-ddb9c73608a1"), "Romance" },
                    { new Guid("12096cda-e448-4dda-94ec-dd9f7e82e0be"), new Guid("cbba306f-f67c-4fb6-bb35-d4fb66f5d155"), "" },
                    { new Guid("1c21c18d-de23-4523-8038-6360d4dc2024"), new Guid("8c1be0da-b1ca-45ef-a18a-ddb9c73608a1"), "Thriller" },
                    { new Guid("236345e0-7a56-4a96-94b7-40599d8fc17d"), new Guid("8c1be0da-b1ca-45ef-a18a-ddb9c73608a1"), "Science-Fiction" },
                    { new Guid("281bfe6d-e2e0-4f8f-8071-efd6be07f919"), new Guid("8c1be0da-b1ca-45ef-a18a-ddb9c73608a1"), "Drama" },
                    { new Guid("2f050e8e-3f93-4ee5-8efd-77ff020d4a09"), new Guid("461f1e2c-ea24-4283-a095-3864526d21b1"), "Moderately often" },
                    { new Guid("48e1e487-8dc8-425f-b50f-d8eace5d4e54"), new Guid("461f1e2c-ea24-4283-a095-3864526d21b1"), "Not at all often" },
                    { new Guid("4f557128-a969-44fa-bb4f-9ddfae234e9c"), new Guid("8c1be0da-b1ca-45ef-a18a-ddb9c73608a1"), "Musical" },
                    { new Guid("50f924dc-e97a-439d-96da-b824e2371e58"), new Guid("57937521-fe6b-4680-8c5e-f3ffccc26bdf"), "" },
                    { new Guid("5f9839d9-75bb-425d-851a-4eae52afd077"), new Guid("8c1be0da-b1ca-45ef-a18a-ddb9c73608a1"), "Horror" },
                    { new Guid("5fa4a9cf-6311-4eef-9235-721ce90489c1"), new Guid("461f1e2c-ea24-4283-a095-3864526d21b1"), "Very often" },
                    { new Guid("ae8ae819-4f2d-486a-9223-e5fd94a57133"), new Guid("8c1be0da-b1ca-45ef-a18a-ddb9c73608a1"), "Comedy" },
                    { new Guid("cd0ad3c3-8386-4de9-a244-4b6226d48ffa"), new Guid("8c1be0da-b1ca-45ef-a18a-ddb9c73608a1"), "Action/Adventure" },
                    { new Guid("daa2914c-2eb0-46d2-9c71-202a3b64a3e2"), new Guid("461f1e2c-ea24-4283-a095-3864526d21b1"), "Extremely often" },
                    { new Guid("fccb65fe-01ba-4381-a806-09f94f491575"), new Guid("91a96e1b-49cc-4580-9e94-32d1932c2408"), "" },
                    { new Guid("ff3813c7-0efe-4f76-9775-41a2c2f78885"), new Guid("461f1e2c-ea24-4283-a095-3864526d21b1"), "Slightly often" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("10dd42ec-39a9-4c4a-bec6-05311551e391"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("12096cda-e448-4dda-94ec-dd9f7e82e0be"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("1c21c18d-de23-4523-8038-6360d4dc2024"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("236345e0-7a56-4a96-94b7-40599d8fc17d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("281bfe6d-e2e0-4f8f-8071-efd6be07f919"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("2f050e8e-3f93-4ee5-8efd-77ff020d4a09"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("48e1e487-8dc8-425f-b50f-d8eace5d4e54"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("4f557128-a969-44fa-bb4f-9ddfae234e9c"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("50f924dc-e97a-439d-96da-b824e2371e58"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("5f9839d9-75bb-425d-851a-4eae52afd077"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("5fa4a9cf-6311-4eef-9235-721ce90489c1"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("ae8ae819-4f2d-486a-9223-e5fd94a57133"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("cd0ad3c3-8386-4de9-a244-4b6226d48ffa"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("daa2914c-2eb0-46d2-9c71-202a3b64a3e2"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("fccb65fe-01ba-4381-a806-09f94f491575"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("ff3813c7-0efe-4f76-9775-41a2c2f78885"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("461f1e2c-ea24-4283-a095-3864526d21b1"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("57937521-fe6b-4680-8c5e-f3ffccc26bdf"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("8c1be0da-b1ca-45ef-a18a-ddb9c73608a1"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("91a96e1b-49cc-4580-9e94-32d1932c2408"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("cbba306f-f67c-4fb6-bb35-d4fb66f5d155"));

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
    }
}
