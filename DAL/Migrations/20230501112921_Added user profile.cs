using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Addeduserprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserProfileGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserProfileGUID);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserGUID",
                table: "UserProfiles",
                column: "UserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");

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
    }
}
