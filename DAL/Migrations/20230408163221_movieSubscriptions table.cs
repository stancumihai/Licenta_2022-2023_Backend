using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class movieSubscriptionstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("1fc959a9-0d1f-4b0f-bfb1-c8cfeed160fa"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("2d3e37ea-1e0b-4a69-bb46-62ac7bb652b3"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("455568b0-389d-4a9f-91aa-86caf1f60c81"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("4fb9a955-2755-4291-a25c-102c829aa355"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("735a8b08-031e-4980-a459-7d57b8a014fb"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("89d839e1-3c9f-47d0-b3fa-699531d6d303"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("af50d0dd-72d1-47a5-839e-26a53ee53c00"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("b0fbfcd3-81f5-49b6-ae7f-1022d26b7094"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("cd9eeb12-0606-4e02-9d2e-17de99b2c03f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("d1560311-90f8-4295-90e5-7e6f27ca8d6a"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("d889cbaa-5092-4752-b0cc-0e25617c2625"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("db4d5d0a-7898-4c65-bb71-63eda1fe9f95"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("e8122d31-4570-483d-807d-2605263ef1c5"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("ee5ea900-7721-44a3-959e-24888311a074"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("f35cd233-d5b7-4747-b88d-c2247c97eba3"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("fcb3a9af-f561-4365-ad34-96c445a47306"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("1b06bb50-a8b7-45a8-b93e-ca4c21ff5382"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("27bce215-205e-4a15-96a1-ad259be45b49"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("72d03562-f994-44d4-aab0-5b311abba269"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("7aa4f744-adc0-4d16-a2cd-794509a3a53e"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("c4892499-a0a2-4e55-b747-e62805c1568e"));

            migrationBuilder.CreateTable(
                name: "MovieSubscriptions",
                columns: table => new
                {
                    MovieSubscriptionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSubscriptions", x => x.MovieSubscriptionGUID);
                    table.ForeignKey(
                        name: "FK_MovieSubscriptions_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSubscriptions_Movies_MovieGUID",
                        column: x => x.MovieGUID,
                        principalTable: "Movies",
                        principalColumn: "MovieGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("1252e712-6ecd-42a2-b59a-0d6951c9688e"), 2, "4.Who is your favourite director?" },
                    { new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("be4c17da-c102-43cd-83d6-73abf2a61ecb"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("d18549f2-e3ea-46cf-837a-1e93f2c914aa"), 1, "3.Who is your favourite actor?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("0e2c85eb-031a-4e0c-b9b5-56bfa1c3757b"), new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), "Very often" },
                    { new Guid("0fd432d1-8cea-4911-b9fa-84fe5064dee6"), new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), "Extremely often" },
                    { new Guid("144ff9bb-b1a3-4b94-bc85-7efeb8298159"), new Guid("d18549f2-e3ea-46cf-837a-1e93f2c914aa"), "" },
                    { new Guid("2a3254d0-0597-4edc-973c-9faccf83e3f4"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Comedy" },
                    { new Guid("30a998ca-b1cb-4546-830f-19b929be9a4b"), new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), "Not at all often" },
                    { new Guid("45a07eaf-0e86-444a-a0e0-e6536af21ad2"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Romance" },
                    { new Guid("4c40bb61-b50e-43ab-8a27-295fab186533"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Musical" },
                    { new Guid("7f3d8175-6a65-4341-8482-18b3809989ce"), new Guid("1252e712-6ecd-42a2-b59a-0d6951c9688e"), "" },
                    { new Guid("7f5c2559-17d3-483b-a4ac-7f8709bf0b7e"), new Guid("be4c17da-c102-43cd-83d6-73abf2a61ecb"), "" },
                    { new Guid("a37fbbcb-a83a-4280-8106-423c26ec5a73"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Action/Adventure" },
                    { new Guid("a62fce64-606d-4194-bdd0-b8435903e1a9"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Horror" },
                    { new Guid("ababf92c-37b5-4ec6-b091-e75dd12f5a08"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Drama" },
                    { new Guid("b13b5642-33a6-4fbe-93d2-1908cf941c7d"), new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), "Moderately often" },
                    { new Guid("c5adcf0f-5416-492a-be21-dd090baf15d7"), new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"), "Slightly often" },
                    { new Guid("cdd05ed4-7a3a-4c1a-832d-a444e721c5fd"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Science-Fiction" },
                    { new Guid("de6fcaec-74f6-4103-bc60-e1c343a21f00"), new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"), "Thriller" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieSubscriptions_MovieGUID",
                table: "MovieSubscriptions",
                column: "MovieGUID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSubscriptions_UserGUID",
                table: "MovieSubscriptions",
                column: "UserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieSubscriptions");

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("0e2c85eb-031a-4e0c-b9b5-56bfa1c3757b"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("0fd432d1-8cea-4911-b9fa-84fe5064dee6"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("144ff9bb-b1a3-4b94-bc85-7efeb8298159"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("2a3254d0-0597-4edc-973c-9faccf83e3f4"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("30a998ca-b1cb-4546-830f-19b929be9a4b"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("45a07eaf-0e86-444a-a0e0-e6536af21ad2"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("4c40bb61-b50e-43ab-8a27-295fab186533"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("7f3d8175-6a65-4341-8482-18b3809989ce"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("7f5c2559-17d3-483b-a4ac-7f8709bf0b7e"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a37fbbcb-a83a-4280-8106-423c26ec5a73"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a62fce64-606d-4194-bdd0-b8435903e1a9"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("ababf92c-37b5-4ec6-b091-e75dd12f5a08"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("b13b5642-33a6-4fbe-93d2-1908cf941c7d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c5adcf0f-5416-492a-be21-dd090baf15d7"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("cdd05ed4-7a3a-4c1a-832d-a444e721c5fd"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("de6fcaec-74f6-4103-bc60-e1c343a21f00"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("1252e712-6ecd-42a2-b59a-0d6951c9688e"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("2770301c-c2cf-4f32-8194-6e4e03327369"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("8a36ce75-c90c-4522-a487-b390fc3f5fd2"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("be4c17da-c102-43cd-83d6-73abf2a61ecb"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("d18549f2-e3ea-46cf-837a-1e93f2c914aa"));

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("1b06bb50-a8b7-45a8-b93e-ca4c21ff5382"), 2, "4.Who is your favourite director?" },
                    { new Guid("27bce215-205e-4a15-96a1-ad259be45b49"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("72d03562-f994-44d4-aab0-5b311abba269"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("7aa4f744-adc0-4d16-a2cd-794509a3a53e"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("c4892499-a0a2-4e55-b747-e62805c1568e"), 1, "3.Who is your favourite actor?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("1fc959a9-0d1f-4b0f-bfb1-c8cfeed160fa"), new Guid("27bce215-205e-4a15-96a1-ad259be45b49"), "" },
                    { new Guid("2d3e37ea-1e0b-4a69-bb46-62ac7bb652b3"), new Guid("1b06bb50-a8b7-45a8-b93e-ca4c21ff5382"), "" },
                    { new Guid("455568b0-389d-4a9f-91aa-86caf1f60c81"), new Guid("72d03562-f994-44d4-aab0-5b311abba269"), "Very often" },
                    { new Guid("4fb9a955-2755-4291-a25c-102c829aa355"), new Guid("72d03562-f994-44d4-aab0-5b311abba269"), "Extremely often" },
                    { new Guid("735a8b08-031e-4980-a459-7d57b8a014fb"), new Guid("7aa4f744-adc0-4d16-a2cd-794509a3a53e"), "Romance" },
                    { new Guid("89d839e1-3c9f-47d0-b3fa-699531d6d303"), new Guid("7aa4f744-adc0-4d16-a2cd-794509a3a53e"), "Action/Adventure" },
                    { new Guid("af50d0dd-72d1-47a5-839e-26a53ee53c00"), new Guid("c4892499-a0a2-4e55-b747-e62805c1568e"), "" },
                    { new Guid("b0fbfcd3-81f5-49b6-ae7f-1022d26b7094"), new Guid("7aa4f744-adc0-4d16-a2cd-794509a3a53e"), "Musical" },
                    { new Guid("cd9eeb12-0606-4e02-9d2e-17de99b2c03f"), new Guid("72d03562-f994-44d4-aab0-5b311abba269"), "Slightly often" },
                    { new Guid("d1560311-90f8-4295-90e5-7e6f27ca8d6a"), new Guid("7aa4f744-adc0-4d16-a2cd-794509a3a53e"), "Thriller" },
                    { new Guid("d889cbaa-5092-4752-b0cc-0e25617c2625"), new Guid("7aa4f744-adc0-4d16-a2cd-794509a3a53e"), "Drama" },
                    { new Guid("db4d5d0a-7898-4c65-bb71-63eda1fe9f95"), new Guid("72d03562-f994-44d4-aab0-5b311abba269"), "Not at all often" },
                    { new Guid("e8122d31-4570-483d-807d-2605263ef1c5"), new Guid("7aa4f744-adc0-4d16-a2cd-794509a3a53e"), "Horror" },
                    { new Guid("ee5ea900-7721-44a3-959e-24888311a074"), new Guid("72d03562-f994-44d4-aab0-5b311abba269"), "Moderately often" },
                    { new Guid("f35cd233-d5b7-4747-b88d-c2247c97eba3"), new Guid("7aa4f744-adc0-4d16-a2cd-794509a3a53e"), "Comedy" },
                    { new Guid("fcb3a9af-f561-4365-ad34-96c445a47306"), new Guid("7aa4f744-adc0-4d16-a2cd-794509a3a53e"), "Science-Fiction" }
                });
        }
    }
}
