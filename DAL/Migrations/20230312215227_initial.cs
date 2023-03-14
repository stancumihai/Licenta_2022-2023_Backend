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
                name: "SurveyAnswers",
                columns: table => new
                {
                    SurveyAnswerGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyQuestionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyAnswerGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    { new Guid("033e11c4-ecbd-4d93-8945-8412af7d5e84"), 3, "1.How frequently do you watch movies?" },
                    { new Guid("151f9f15-c839-4706-8130-dee51e277169"), 0, "2.Out of all the movies you have ever seen, which is your most favourite?" },
                    { new Guid("484a41a6-2aab-45f3-9b89-39b73bfb9248"), 2, "4.Who is your favourite director?" },
                    { new Guid("6708b211-1ab5-4e3b-82b8-2c514c624f53"), 3, "5.What are your top 3 favourite kind of genres?" },
                    { new Guid("74fda842-522d-4a01-9cb3-5792825ae6cc"), 1, "3.Who is your favourite actor?" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerGUID", "SurveyQuestionGUID", "Value" },
                values: new object[,]
                {
                    { new Guid("13c3768f-b65d-4335-a1d3-1237a9dee323"), new Guid("033e11c4-ecbd-4d93-8945-8412af7d5e84"), "Extremely often" },
                    { new Guid("1bc97a69-78b2-4b7b-9775-fcbbcb0e1aca"), new Guid("6708b211-1ab5-4e3b-82b8-2c514c624f53"), "Musical" },
                    { new Guid("2682f6d5-95b6-4d95-969d-f5927565356a"), new Guid("6708b211-1ab5-4e3b-82b8-2c514c624f53"), "Science-Fiction" },
                    { new Guid("376ac2d0-3560-407f-8228-8494534a2481"), new Guid("484a41a6-2aab-45f3-9b89-39b73bfb9248"), "" },
                    { new Guid("3e8db6e0-821e-4706-99b2-da8e7614f776"), new Guid("151f9f15-c839-4706-8130-dee51e277169"), "" },
                    { new Guid("75c8c08c-993f-4f5f-94e3-406fba55f400"), new Guid("033e11c4-ecbd-4d93-8945-8412af7d5e84"), "Very often" },
                    { new Guid("92635bf1-779c-4a08-bb90-b503d7f1fc75"), new Guid("6708b211-1ab5-4e3b-82b8-2c514c624f53"), "Thriller" },
                    { new Guid("940dc8ae-3cf6-4a10-bb58-3b8527d2a0c6"), new Guid("033e11c4-ecbd-4d93-8945-8412af7d5e84"), "Moderately often" },
                    { new Guid("a7b2a252-96b9-4e53-ad5e-c4ee5748938b"), new Guid("033e11c4-ecbd-4d93-8945-8412af7d5e84"), "Not at all often" },
                    { new Guid("ae70f5b6-9cb2-494c-8d5b-a8f9d65d1e70"), new Guid("74fda842-522d-4a01-9cb3-5792825ae6cc"), "" },
                    { new Guid("b5ad8ed8-b22e-45ab-b0a2-874ff5b1c4f0"), new Guid("6708b211-1ab5-4e3b-82b8-2c514c624f53"), "Comedy" },
                    { new Guid("baee7704-2583-4053-98c1-c4e887ec6177"), new Guid("033e11c4-ecbd-4d93-8945-8412af7d5e84"), "Slightly often" },
                    { new Guid("cd0953b1-19fb-490c-abd0-f10eb8d29175"), new Guid("6708b211-1ab5-4e3b-82b8-2c514c624f53"), "Horror" },
                    { new Guid("d367ed2b-5bde-47f8-8029-3740d3f569ef"), new Guid("6708b211-1ab5-4e3b-82b8-2c514c624f53"), "Romance" },
                    { new Guid("e3fd09a8-16bf-4212-a93f-365c16baa74f"), new Guid("6708b211-1ab5-4e3b-82b8-2c514c624f53"), "Drama" },
                    { new Guid("ff90c783-f5a5-4d5a-a274-447283c467b7"), new Guid("6708b211-1ab5-4e3b-82b8-2c514c624f53"), "Action/Adventure" }
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
                name: "SurveyUserAnswers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SurveyAnswers");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");
        }
    }
}
