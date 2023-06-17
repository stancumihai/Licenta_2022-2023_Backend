using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class likedMoviestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("12db1052-6eaa-4a05-abe8-4d8713479d42"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("1530c194-a7f6-4914-b00d-ed33dc6ea21a"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("1f104c4a-d666-4824-969d-b15f0b0ad95f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("28badaf1-8d8f-4f78-ad79-b683b63589b3"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("6fde0146-b86e-431e-9d66-6bd31a0f650b"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("737fbdc5-fc5e-48b5-ae5b-872d4a75d846"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("7a23fb04-366c-4560-aba3-e27627b69458"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("7a6d179a-eaf1-4910-ad25-d1f31807ae0a"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("7c228cd2-5f9b-49e8-ab42-30308e5c4d72"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("b1be8276-3c33-4fe8-a808-c984c6eb40de"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("b84a2d9f-b891-44b7-889c-56b86f707430"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("d0032cde-6413-4161-89dd-0a8b0858814a"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("da6cd3ed-62aa-4230-ad2a-be21d24d3a11"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("de06dbd5-a91e-46fc-8b8a-71b6b44a3a5e"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("fc937c71-2fab-453c-a835-e12bafaee856"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("fdaa2389-b32e-46b2-9052-fb0b90a5a843"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("1653fc4d-935e-413b-bcf3-3a3b787eaea0"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("6958c642-1b7e-4869-95ab-b19268882c2c"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("c7f15a58-d7dc-4cb0-8335-31597810cb8d"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("ce5aa2a9-c154-4cbc-829b-c403625e5bf0"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("d95ff132-c357-4b18-b3fc-00216c42956f"));

            migrationBuilder.CreateTable(
                name: "LikedMovies",
                columns: table => new
                {
                    LikedMovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedMovies", x => x.LikedMovieGUID);
                    table.ForeignKey(
                        name: "FK_LikedMovies_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedMovies_Movies_MovieGUID",
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

            migrationBuilder.CreateIndex(
                name: "IX_LikedMovies_MovieGUID",
                table: "LikedMovies",
                column: "MovieGUID");

            migrationBuilder.CreateIndex(
                name: "IX_LikedMovies_UserGUID",
                table: "LikedMovies",
                column: "UserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedMovies");

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

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("1653fc4d-935e-413b-bcf3-3a3b787eaea0"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("6958c642-1b7e-4869-95ab-b19268882c2c"), 1, "3.Who is your favourite actor?" },
                    { new Guid("c7f15a58-d7dc-4cb0-8335-31597810cb8d"), 2, "4.Who is your favourite director?" },
                    { new Guid("ce5aa2a9-c154-4cbc-829b-c403625e5bf0"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("d95ff132-c357-4b18-b3fc-00216c42956f"), 3, "1.How frequently do you watch movies?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("12db1052-6eaa-4a05-abe8-4d8713479d42"), new Guid("1653fc4d-935e-413b-bcf3-3a3b787eaea0"), "" },
                    { new Guid("1530c194-a7f6-4914-b00d-ed33dc6ea21a"), new Guid("d95ff132-c357-4b18-b3fc-00216c42956f"), "Moderately often" },
                    { new Guid("1f104c4a-d666-4824-969d-b15f0b0ad95f"), new Guid("ce5aa2a9-c154-4cbc-829b-c403625e5bf0"), "Romance" },
                    { new Guid("28badaf1-8d8f-4f78-ad79-b683b63589b3"), new Guid("ce5aa2a9-c154-4cbc-829b-c403625e5bf0"), "Musical" },
                    { new Guid("6fde0146-b86e-431e-9d66-6bd31a0f650b"), new Guid("ce5aa2a9-c154-4cbc-829b-c403625e5bf0"), "Thriller" },
                    { new Guid("737fbdc5-fc5e-48b5-ae5b-872d4a75d846"), new Guid("ce5aa2a9-c154-4cbc-829b-c403625e5bf0"), "Drama" },
                    { new Guid("7a23fb04-366c-4560-aba3-e27627b69458"), new Guid("ce5aa2a9-c154-4cbc-829b-c403625e5bf0"), "Comedy" },
                    { new Guid("7a6d179a-eaf1-4910-ad25-d1f31807ae0a"), new Guid("6958c642-1b7e-4869-95ab-b19268882c2c"), "" },
                    { new Guid("7c228cd2-5f9b-49e8-ab42-30308e5c4d72"), new Guid("d95ff132-c357-4b18-b3fc-00216c42956f"), "Slightly often" },
                    { new Guid("b1be8276-3c33-4fe8-a808-c984c6eb40de"), new Guid("d95ff132-c357-4b18-b3fc-00216c42956f"), "Very often" },
                    { new Guid("b84a2d9f-b891-44b7-889c-56b86f707430"), new Guid("ce5aa2a9-c154-4cbc-829b-c403625e5bf0"), "Science-Fiction" },
                    { new Guid("d0032cde-6413-4161-89dd-0a8b0858814a"), new Guid("ce5aa2a9-c154-4cbc-829b-c403625e5bf0"), "Action/Adventure" },
                    { new Guid("da6cd3ed-62aa-4230-ad2a-be21d24d3a11"), new Guid("c7f15a58-d7dc-4cb0-8335-31597810cb8d"), "" },
                    { new Guid("de06dbd5-a91e-46fc-8b8a-71b6b44a3a5e"), new Guid("d95ff132-c357-4b18-b3fc-00216c42956f"), "Extremely often" },
                    { new Guid("fc937c71-2fab-453c-a835-e12bafaee856"), new Guid("ce5aa2a9-c154-4cbc-829b-c403625e5bf0"), "Horror" },
                    { new Guid("fdaa2389-b32e-46b2-9052-fb0b90a5a843"), new Guid("d95ff132-c357-4b18-b3fc-00216c42956f"), "Not at all often" }
                });
        }
    }
}
