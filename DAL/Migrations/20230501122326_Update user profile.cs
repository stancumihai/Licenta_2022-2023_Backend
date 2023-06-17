using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Updateuserprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("02a31bcb-5172-4e31-a309-ab2a03c8ee0c"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("11c9b92b-b3eb-4ea8-9ced-0669554002c1"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("22e5fa33-5b0e-4218-ae66-77c0f08e840d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("2f78a448-3120-48f2-a52a-c9b109297aaf"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("383f707c-faa0-4e16-80a9-acbc1eceb076"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("3cbb8d98-aaca-4f0c-93df-bd112e708c3a"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("4ac570e5-02bc-467d-90a8-b6d349f3029f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("5d04615a-b6a2-4f09-ad9b-ced822757ec3"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("79e0c694-5517-4559-9eaa-6980e9c8978b"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("98bf4d0a-c302-4376-81c3-deb3ca657032"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("9ef10314-05cf-4cac-bc5d-86d81c28e679"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a9a93119-b28c-4a37-8748-617eec311b00"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("aad0a195-4d8a-4570-95ad-85d6c6a4e1ee"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("bcea9642-e2ee-4fb5-abbf-7ff8f3047aca"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("d99b0801-8f57-4694-87e0-bc7018a0c193"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("dde07f8c-cf1a-4438-8869-bcaa2f966f8d"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("629d377f-365d-471f-8fe1-b11cb4675129"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("d5b30202-448a-4af5-b329-10a3420dd336"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("deefe546-6194-4211-ae4d-01d25e5c14ed"));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "UserProfiles");

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("629d377f-365d-471f-8fe1-b11cb4675129"), 2, "4.Who is your favourite director?" },
                    { new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("d5b30202-448a-4af5-b329-10a3420dd336"), 1, "3.Who is your favourite actor?" },
                    { new Guid("deefe546-6194-4211-ae4d-01d25e5c14ed"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("02a31bcb-5172-4e31-a309-ab2a03c8ee0c"), new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"), "Musical" },
                    { new Guid("11c9b92b-b3eb-4ea8-9ced-0669554002c1"), new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"), "Slightly often" },
                    { new Guid("22e5fa33-5b0e-4218-ae66-77c0f08e840d"), new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"), "Horror" },
                    { new Guid("2f78a448-3120-48f2-a52a-c9b109297aaf"), new Guid("d5b30202-448a-4af5-b329-10a3420dd336"), "" },
                    { new Guid("383f707c-faa0-4e16-80a9-acbc1eceb076"), new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"), "Action/Adventure" },
                    { new Guid("3cbb8d98-aaca-4f0c-93df-bd112e708c3a"), new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"), "Extremely often" },
                    { new Guid("4ac570e5-02bc-467d-90a8-b6d349f3029f"), new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"), "Very often" },
                    { new Guid("5d04615a-b6a2-4f09-ad9b-ced822757ec3"), new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"), "Romance" },
                    { new Guid("79e0c694-5517-4559-9eaa-6980e9c8978b"), new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"), "Moderately often" },
                    { new Guid("98bf4d0a-c302-4376-81c3-deb3ca657032"), new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"), "Not at all often" },
                    { new Guid("9ef10314-05cf-4cac-bc5d-86d81c28e679"), new Guid("629d377f-365d-471f-8fe1-b11cb4675129"), "" },
                    { new Guid("a9a93119-b28c-4a37-8748-617eec311b00"), new Guid("deefe546-6194-4211-ae4d-01d25e5c14ed"), "" },
                    { new Guid("aad0a195-4d8a-4570-95ad-85d6c6a4e1ee"), new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"), "Drama" },
                    { new Guid("bcea9642-e2ee-4fb5-abbf-7ff8f3047aca"), new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"), "Comedy" },
                    { new Guid("d99b0801-8f57-4694-87e0-bc7018a0c193"), new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"), "Science-Fiction" },
                    { new Guid("dde07f8c-cf1a-4438-8869-bcaa2f966f8d"), new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"), "Thriller" }
                });
        }
    }
}
