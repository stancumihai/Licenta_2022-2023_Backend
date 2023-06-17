using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfRelease = table.Column<int>(type: "int", nullable: false),
                    Runtime = table.Column<int>(type: "int", nullable: false),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieGUID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfBirth = table.Column<int>(type: "int", nullable: false),
                    YearOfDeath = table.Column<int>(type: "int", nullable: false),
                    Professions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonGUID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    SurveyQuestionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.SurveyQuestionGUID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieRatings",
                columns: table => new
                {
                    MovieRatingGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VotesNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRatings", x => x.MovieRatingGUID);
                    table.ForeignKey(
                        name: "FK_MovieRatings_Movies_MovieGUID",
                        column: x => x.MovieGUID,
                        principalTable: "Movies",
                        principalColumn: "MovieGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnownFor",
                columns: table => new
                {
                    KnownForGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownFor", x => x.KnownForGUID);
                    table.ForeignKey(
                        name: "FK_KnownFor_Movies_MovieGUID",
                        column: x => x.MovieGUID,
                        principalTable: "Movies",
                        principalColumn: "MovieGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnownFor_Persons_PersonGUID",
                        column: x => x.PersonGUID,
                        principalTable: "Persons",
                        principalColumn: "PersonGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswers",
                columns: table => new
                {
                    SurveyAnswerGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyQuestionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswers", x => x.SurveyAnswerGUID);
                    table.ForeignKey(
                        name: "FK_SurveyAnswers_SurveyQuestions_SurveyQuestionGUID",
                        column: x => x.SurveyQuestionGUID,
                        principalTable: "SurveyQuestions",
                        principalColumn: "SurveyQuestionGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyUserAnswers",
                columns: table => new
                {
                    SurveyUserAnswerGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurveyQuestionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyAnswerGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyUserAnswers", x => x.SurveyUserAnswerGUID);
                    table.ForeignKey(
                        name: "FK_SurveyUserAnswers_AspNetUsers_UserGUID",
                        column: x => x.UserGUID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyUserAnswers_SurveyAnswers_SurveyAnswerGUID",
                        column: x => x.SurveyAnswerGUID,
                        principalTable: "SurveyAnswers",
                        principalColumn: "SurveyAnswerGUID");
                    table.ForeignKey(
                        name: "FK_SurveyUserAnswers_SurveyQuestions_SurveyQuestionGUID",
                        column: x => x.SurveyQuestionGUID,
                        principalTable: "SurveyQuestions",
                        principalColumn: "SurveyQuestionGUID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KnownFor_MovieGUID",
                table: "KnownFor",
                column: "MovieGUID");

            migrationBuilder.CreateIndex(
                name: "IX_KnownFor_PersonGUID",
                table: "KnownFor",
                column: "PersonGUID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRatings_MovieGUID",
                table: "MovieRatings",
                column: "MovieGUID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswers_SurveyQuestionGUID",
                table: "SurveyAnswers",
                column: "SurveyQuestionGUID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyUserAnswers_SurveyAnswerGUID",
                table: "SurveyUserAnswers",
                column: "SurveyAnswerGUID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyUserAnswers_SurveyQuestionGUID",
                table: "SurveyUserAnswers",
                column: "SurveyQuestionGUID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyUserAnswers_UserGUID",
                table: "SurveyUserAnswers",
                column: "UserGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "KnownFor");

            migrationBuilder.DropTable(
                name: "MovieRatings");

            migrationBuilder.DropTable(
                name: "SurveyUserAnswers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SurveyAnswers");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");
        }
    }
}
