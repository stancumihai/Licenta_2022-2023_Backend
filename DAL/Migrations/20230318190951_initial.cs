using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { new Guid("625ce2a7-c26b-41c7-8d30-82f8143091e7"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("795b3cad-c7a9-461f-be05-cdd2aceeb57e"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("882535a9-ed97-4c79-816c-1b868e98cda8"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("c7921377-7c6e-41dc-aead-bd52fc341fca"), 2, "4.Who is your favourite director?" },
                    { new Guid("d953ee29-72ad-4f7a-a1a3-25cf367f65a3"), 1, "3.Who is your favourite actor?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("138726c0-6acf-446b-a217-2ad18389b454"), new Guid("625ce2a7-c26b-41c7-8d30-82f8143091e7"), "Slightly often" },
                    { new Guid("13d7eda3-8c17-4702-98dc-45d149ab2037"), new Guid("625ce2a7-c26b-41c7-8d30-82f8143091e7"), "Moderately often" },
                    { new Guid("35aeb7cc-48f7-47ce-8cc0-0686e5a2537e"), new Guid("795b3cad-c7a9-461f-be05-cdd2aceeb57e"), "Horror" },
                    { new Guid("54a8a8b3-f566-4e83-b032-37a22fae2f07"), new Guid("795b3cad-c7a9-461f-be05-cdd2aceeb57e"), "Drama" },
                    { new Guid("5a904b22-7d7f-4c55-8d31-59d6c6395705"), new Guid("795b3cad-c7a9-461f-be05-cdd2aceeb57e"), "Comedy" },
                    { new Guid("796ce628-c742-4363-994a-710793e9b8f5"), new Guid("795b3cad-c7a9-461f-be05-cdd2aceeb57e"), "Romance" },
                    { new Guid("8db6917f-d44c-4074-ae58-0ca42b09d4eb"), new Guid("625ce2a7-c26b-41c7-8d30-82f8143091e7"), "Very often" },
                    { new Guid("91221e1a-34f1-48be-8178-7e9b3b55a1c2"), new Guid("625ce2a7-c26b-41c7-8d30-82f8143091e7"), "Extremely often" },
                    { new Guid("975840bf-3cbe-4fe9-a1bf-a93840cf757d"), new Guid("625ce2a7-c26b-41c7-8d30-82f8143091e7"), "Not at all often" },
                    { new Guid("9866c84d-8342-4b08-a124-f1b870670875"), new Guid("882535a9-ed97-4c79-816c-1b868e98cda8"), "" },
                    { new Guid("ad13ebef-5888-4bb1-af96-5552c8b58108"), new Guid("d953ee29-72ad-4f7a-a1a3-25cf367f65a3"), "" },
                    { new Guid("ba5aa5e3-f55f-46f6-bc9d-498c197e5f18"), new Guid("795b3cad-c7a9-461f-be05-cdd2aceeb57e"), "Thriller" },
                    { new Guid("db630b93-92e2-4ac0-a914-bcb9e43d9a82"), new Guid("795b3cad-c7a9-461f-be05-cdd2aceeb57e"), "Musical" },
                    { new Guid("dfc12ad8-7f8c-46f6-83d2-2c0907de1dc4"), new Guid("795b3cad-c7a9-461f-be05-cdd2aceeb57e"), "Action/Adventure" },
                    { new Guid("efe44b9d-5d15-4f75-9932-1dcb39edeab0"), new Guid("795b3cad-c7a9-461f-be05-cdd2aceeb57e"), "Science-Fiction" },
                    { new Guid("f88c5a22-610a-4c88-adf5-86b892696631"), new Guid("c7921377-7c6e-41dc-aead-bd52fc341fca"), "" }
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
