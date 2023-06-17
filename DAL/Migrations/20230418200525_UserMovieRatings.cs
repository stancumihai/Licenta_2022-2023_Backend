using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserMovieRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("02ae396b-c39e-4039-88e1-0a5bf8220cf0"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("082286b0-8459-4775-93e9-5b78c28a8f80"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("1242bcdd-639f-4a95-b637-52983404bbaf"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("199177f5-9fec-4466-bfea-4916e08e3020"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("5dd625b2-5149-4188-8a07-808928fc228d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("79e99f78-ae0a-4330-97b0-3f25f327eb8d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("8e040ca0-51df-493a-b67d-a997edf559de"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("948f7a9d-aa95-4edf-8fce-b061af1d70f2"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a1978dc5-bee9-4449-afe5-d26cbdb80c3e"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("a5b503eb-bead-453d-9752-c1adc186007f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("b331d8f2-2559-4a99-b430-0c6bd5feb2c8"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c4f78d20-1740-41af-98d1-9a914de517b5"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("c5490393-73bb-4540-b8a9-e91ff9c8308d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("d3db1692-f62e-4d47-938c-ca213cbe87dc"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("dd713fba-5803-4db4-8c99-c6a56701483b"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("f55810c0-5b5e-4531-8b4e-03bc11136dab"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("72ca54af-43c1-481a-82ef-aef117f1c09b"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("c28c92ba-afa1-406c-b07e-f0611133187a"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("e2e67ba5-7387-44ea-8957-a964f81f2138"));

            migrationBuilder.CreateTable(
                name: "UserMovieRatings",
                columns: table => new
                {
                    UserMovieRatingGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieRatings", x => x.UserMovieRatingGUID);
                    table.ForeignKey(
                        name: "FK_UserMovieRatings_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovieRatings_Movies_MovieGUID",
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
                    { new Guid("1cb68441-8f10-4855-b2be-ef5e5f12760b"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("3ce0f0a8-ab6b-4642-85f6-2d6182e35447"), 2, "4.Who is your favourite director?" },
                    { new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("5db8e0ab-ffaa-45e5-af7b-0dcb0206f642"), 1, "3.Who is your favourite actor?" },
                    { new Guid("96da0d84-f192-469e-b71c-f9658960a601"), 3, "1.How frequently do you watch movies?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("29a484e0-7311-45c8-a384-aedaf1106871"), new Guid("3ce0f0a8-ab6b-4642-85f6-2d6182e35447"), "" },
                    { new Guid("2d5c0672-c6a6-44ee-9b22-aba07e6b1c30"), new Guid("96da0d84-f192-469e-b71c-f9658960a601"), "Moderately often" },
                    { new Guid("43aa1f81-6382-4bd2-a893-02d65f78a910"), new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"), "Action/Adventure" },
                    { new Guid("4bb0cb91-d1d9-4625-9229-7f35c849dd66"), new Guid("96da0d84-f192-469e-b71c-f9658960a601"), "Extremely often" },
                    { new Guid("57d011ec-4cde-466b-ad58-f27d0a325573"), new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"), "Drama" },
                    { new Guid("586a009e-d4e4-42bd-94d7-547a613d143c"), new Guid("5db8e0ab-ffaa-45e5-af7b-0dcb0206f642"), "" },
                    { new Guid("5f21101b-5124-484b-8d64-05f865907012"), new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"), "Thriller" },
                    { new Guid("68a946dd-3a1a-4b0b-9a60-d2709904223f"), new Guid("96da0d84-f192-469e-b71c-f9658960a601"), "Not at all often" },
                    { new Guid("69544180-dd55-406f-ba6a-4a3cf8ac5704"), new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"), "Comedy" },
                    { new Guid("7673ebd4-1360-4dd9-8ba5-fb6174a18161"), new Guid("1cb68441-8f10-4855-b2be-ef5e5f12760b"), "" },
                    { new Guid("8ed7b0c2-d757-42d3-b164-ddf3cc3ec2ab"), new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"), "Science-Fiction" },
                    { new Guid("901c164f-b747-450f-9218-91ea61385ef2"), new Guid("96da0d84-f192-469e-b71c-f9658960a601"), "Slightly often" },
                    { new Guid("91d35212-1387-4d5f-be84-838ea568b3e3"), new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"), "Romance" },
                    { new Guid("9a62dcb1-340d-4dfd-a429-f4890db77ee2"), new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"), "Musical" },
                    { new Guid("d326ea60-a907-4975-92af-a6602f16a1b4"), new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"), "Horror" },
                    { new Guid("d618d73e-4aeb-4ca4-879d-df9ba1939248"), new Guid("96da0d84-f192-469e-b71c-f9658960a601"), "Very often" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieRatings_MovieGUID",
                table: "UserMovieRatings",
                column: "MovieGUID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieRatings_UserGUID",
                table: "UserMovieRatings",
                column: "UserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMovieRatings");

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("29a484e0-7311-45c8-a384-aedaf1106871"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("2d5c0672-c6a6-44ee-9b22-aba07e6b1c30"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("43aa1f81-6382-4bd2-a893-02d65f78a910"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("4bb0cb91-d1d9-4625-9229-7f35c849dd66"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("57d011ec-4cde-466b-ad58-f27d0a325573"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("586a009e-d4e4-42bd-94d7-547a613d143c"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("5f21101b-5124-484b-8d64-05f865907012"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("68a946dd-3a1a-4b0b-9a60-d2709904223f"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("69544180-dd55-406f-ba6a-4a3cf8ac5704"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("7673ebd4-1360-4dd9-8ba5-fb6174a18161"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("8ed7b0c2-d757-42d3-b164-ddf3cc3ec2ab"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("901c164f-b747-450f-9218-91ea61385ef2"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("91d35212-1387-4d5f-be84-838ea568b3e3"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("9a62dcb1-340d-4dfd-a429-f4890db77ee2"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("d326ea60-a907-4975-92af-a6602f16a1b4"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerGUID",
                keyValue: new Guid("d618d73e-4aeb-4ca4-879d-df9ba1939248"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("1cb68441-8f10-4855-b2be-ef5e5f12760b"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("3ce0f0a8-ab6b-4642-85f6-2d6182e35447"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("5db8e0ab-ffaa-45e5-af7b-0dcb0206f642"));

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "SurveyQuestionGUID",
                keyValue: new Guid("96da0d84-f192-469e-b71c-f9658960a601"));

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "SurveyQuestionGUID", "Category", "Value" },
                values: new object[,]
                {
                    { new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("72ca54af-43c1-481a-82ef-aef117f1c09b"), 1, "3.Who is your favourite actor?" },
                    { new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("c28c92ba-afa1-406c-b07e-f0611133187a"), 2, "4.Who is your favourite director?" },
                    { new Guid("e2e67ba5-7387-44ea-8957-a964f81f2138"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("02ae396b-c39e-4039-88e1-0a5bf8220cf0"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Horror" },
                    { new Guid("082286b0-8459-4775-93e9-5b78c28a8f80"), new Guid("c28c92ba-afa1-406c-b07e-f0611133187a"), "" },
                    { new Guid("1242bcdd-639f-4a95-b637-52983404bbaf"), new Guid("72ca54af-43c1-481a-82ef-aef117f1c09b"), "" },
                    { new Guid("199177f5-9fec-4466-bfea-4916e08e3020"), new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), "Very often" },
                    { new Guid("5dd625b2-5149-4188-8a07-808928fc228d"), new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), "Extremely often" },
                    { new Guid("79e99f78-ae0a-4330-97b0-3f25f327eb8d"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Action/Adventure" },
                    { new Guid("8e040ca0-51df-493a-b67d-a997edf559de"), new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), "Moderately often" },
                    { new Guid("948f7a9d-aa95-4edf-8fce-b061af1d70f2"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Science-Fiction" },
                    { new Guid("a1978dc5-bee9-4449-afe5-d26cbdb80c3e"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Thriller" },
                    { new Guid("a5b503eb-bead-453d-9752-c1adc186007f"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Drama" },
                    { new Guid("b331d8f2-2559-4a99-b430-0c6bd5feb2c8"), new Guid("e2e67ba5-7387-44ea-8957-a964f81f2138"), "" },
                    { new Guid("c4f78d20-1740-41af-98d1-9a914de517b5"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Romance" },
                    { new Guid("c5490393-73bb-4540-b8a9-e91ff9c8308d"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Musical" },
                    { new Guid("d3db1692-f62e-4d47-938c-ca213cbe87dc"), new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), "Slightly often" },
                    { new Guid("dd713fba-5803-4db4-8c99-c6a56701483b"), new Guid("40bc9101-7221-4b6b-875d-99e89e8e16e9"), "Not at all often" },
                    { new Guid("f55810c0-5b5e-4531-8b4e-03bc11136dab"), new Guid("b1a6057f-a991-4acb-b50d-a5714d3e512c"), "Comedy" }
                });
        }
    }
}
