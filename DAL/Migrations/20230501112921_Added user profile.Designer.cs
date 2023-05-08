﻿// <auto-generated />
using System;
using DAL.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230501112921_Added user profile")]
    partial class Addeduserprofile
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DAL.Models.KnownFor", b =>
                {
                    b.Property<Guid>("KnownForGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonGUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("KnownForGUID");

                    b.HasIndex("MovieGUID");

                    b.HasIndex("PersonGUID");

                    b.ToTable("KnownFor");
                });

            modelBuilder.Entity("DAL.Models.LikedMovie", b =>
                {
                    b.Property<Guid>("LikedMovieGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MovieGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserGUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LikedMovieGUID");

                    b.HasIndex("MovieGUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("LikedMovies");
                });

            modelBuilder.Entity("DAL.Models.Movie", b =>
                {
                    b.Property<Guid>("MovieGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Runtime")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("int");

                    b.HasKey("MovieGUID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("DAL.Models.MovieRating", b =>
                {
                    b.Property<Guid>("MovieRatingGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AverageRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("MovieGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("VotesNumber")
                        .HasColumnType("bigint");

                    b.HasKey("MovieRatingGUID");

                    b.HasIndex("MovieGUID");

                    b.ToTable("MovieRatings");
                });

            modelBuilder.Entity("DAL.Models.MovieSubscription", b =>
                {
                    b.Property<Guid>("MovieSubscriptionGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserGUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MovieSubscriptionGUID");

                    b.HasIndex("MovieGUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("MovieSubscriptions");
                });

            modelBuilder.Entity("DAL.Models.Person", b =>
                {
                    b.Property<Guid>("PersonGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Professions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfBirth")
                        .HasColumnType("int");

                    b.Property<int>("YearOfDeath")
                        .HasColumnType("int");

                    b.HasKey("PersonGUID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DAL.Models.SeenMovie", b =>
                {
                    b.Property<Guid>("SeenMovieGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MovieGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserGUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SeenMovieGUID");

                    b.HasIndex("MovieGUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("SeenMovies");
                });

            modelBuilder.Entity("DAL.Models.SurveyAnswer", b =>
                {
                    b.Property<Guid>("SurveyAnswerGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SurveyQuestionGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SurveyAnswerGUID");

                    b.HasIndex("SurveyQuestionGUID");

                    b.ToTable("SurveyAnswers");

                    b.HasData(
                        new
                        {
                            SurveyAnswerGUID = new Guid("3cbb8d98-aaca-4f0c-93df-bd112e708c3a"),
                            SurveyQuestionGUID = new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"),
                            Value = "Extremely often"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("4ac570e5-02bc-467d-90a8-b6d349f3029f"),
                            SurveyQuestionGUID = new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"),
                            Value = "Very often"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("79e0c694-5517-4559-9eaa-6980e9c8978b"),
                            SurveyQuestionGUID = new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"),
                            Value = "Moderately often"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("11c9b92b-b3eb-4ea8-9ced-0669554002c1"),
                            SurveyQuestionGUID = new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"),
                            Value = "Slightly often"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("98bf4d0a-c302-4376-81c3-deb3ca657032"),
                            SurveyQuestionGUID = new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"),
                            Value = "Not at all often"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("a9a93119-b28c-4a37-8748-617eec311b00"),
                            SurveyQuestionGUID = new Guid("deefe546-6194-4211-ae4d-01d25e5c14ed"),
                            Value = ""
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("2f78a448-3120-48f2-a52a-c9b109297aaf"),
                            SurveyQuestionGUID = new Guid("d5b30202-448a-4af5-b329-10a3420dd336"),
                            Value = ""
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("9ef10314-05cf-4cac-bc5d-86d81c28e679"),
                            SurveyQuestionGUID = new Guid("629d377f-365d-471f-8fe1-b11cb4675129"),
                            Value = ""
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("22e5fa33-5b0e-4218-ae66-77c0f08e840d"),
                            SurveyQuestionGUID = new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"),
                            Value = "Horror"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("5d04615a-b6a2-4f09-ad9b-ced822757ec3"),
                            SurveyQuestionGUID = new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"),
                            Value = "Romance"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("383f707c-faa0-4e16-80a9-acbc1eceb076"),
                            SurveyQuestionGUID = new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"),
                            Value = "Action/Adventure"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("dde07f8c-cf1a-4438-8869-bcaa2f966f8d"),
                            SurveyQuestionGUID = new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"),
                            Value = "Thriller"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("d99b0801-8f57-4694-87e0-bc7018a0c193"),
                            SurveyQuestionGUID = new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"),
                            Value = "Science-Fiction"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("bcea9642-e2ee-4fb5-abbf-7ff8f3047aca"),
                            SurveyQuestionGUID = new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"),
                            Value = "Comedy"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("aad0a195-4d8a-4570-95ad-85d6c6a4e1ee"),
                            SurveyQuestionGUID = new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"),
                            Value = "Drama"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("02a31bcb-5172-4e31-a309-ab2a03c8ee0c"),
                            SurveyQuestionGUID = new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"),
                            Value = "Musical"
                        });
                });

            modelBuilder.Entity("DAL.Models.SurveyQuestion", b =>
                {
                    b.Property<Guid>("SurveyQuestionGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SurveyQuestionGUID");

                    b.ToTable("SurveyQuestions");

                    b.HasData(
                        new
                        {
                            SurveyQuestionGUID = new Guid("5ab9fcdf-a202-4976-b57e-8e646139bb56"),
                            Category = 3,
                            Value = "1.How frequently do you watch movies?"
                        },
                        new
                        {
                            SurveyQuestionGUID = new Guid("deefe546-6194-4211-ae4d-01d25e5c14ed"),
                            Category = 0,
                            Value = "2.Out of all the movies you have ever seen, which is your most favourite?"
                        },
                        new
                        {
                            SurveyQuestionGUID = new Guid("d5b30202-448a-4af5-b329-10a3420dd336"),
                            Category = 1,
                            Value = "3.Who is your favourite actor?"
                        },
                        new
                        {
                            SurveyQuestionGUID = new Guid("629d377f-365d-471f-8fe1-b11cb4675129"),
                            Category = 2,
                            Value = "4.Who is your favourite director?"
                        },
                        new
                        {
                            SurveyQuestionGUID = new Guid("baf6c761-861a-4446-9e02-b6a927ed9efc"),
                            Category = 3,
                            Value = "5.What are your top 3 favourite kind of genres?"
                        });
                });

            modelBuilder.Entity("DAL.Models.SurveyUserAnswer", b =>
                {
                    b.Property<Guid>("SurveyUserAnswerGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SurveyAnswerGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SurveyQuestionGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserGUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SurveyUserAnswerGUID");

                    b.HasIndex("SurveyAnswerGUID");

                    b.HasIndex("SurveyQuestionGUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("SurveyUserAnswers");
                });

            modelBuilder.Entity("DAL.Models.UserMovieRating", b =>
                {
                    b.Property<Guid>("UserMovieRatingGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserGUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserMovieRatingGUID");

                    b.HasIndex("MovieGUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("UserMovieRatings");
                });

            modelBuilder.Entity("DAL.Models.UserProfile", b =>
                {
                    b.Property<Guid>("UserProfileGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserGUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserProfileGUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DAL.Models.KnownFor", b =>
                {
                    b.HasOne("DAL.Models.Movie", "Movie")
                        .WithMany("KnowFor")
                        .HasForeignKey("MovieGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany("KnowFor")
                        .HasForeignKey("PersonGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DAL.Models.LikedMovie", b =>
                {
                    b.HasOne("DAL.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.MovieRating", b =>
                {
                    b.HasOne("DAL.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("DAL.Models.MovieSubscription", b =>
                {
                    b.HasOne("DAL.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.SeenMovie", b =>
                {
                    b.HasOne("DAL.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.SurveyAnswer", b =>
                {
                    b.HasOne("DAL.Models.SurveyQuestion", "SurveyQuestion")
                        .WithMany("SurveyAnswers")
                        .HasForeignKey("SurveyQuestionGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SurveyQuestion");
                });

            modelBuilder.Entity("DAL.Models.SurveyUserAnswer", b =>
                {
                    b.HasOne("DAL.Models.SurveyAnswer", "SurveyAnswer")
                        .WithMany()
                        .HasForeignKey("SurveyAnswerGUID");

                    b.HasOne("DAL.Models.SurveyQuestion", "SurveyQuestion")
                        .WithMany()
                        .HasForeignKey("SurveyQuestionGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany("SurveyUserAnswers")
                        .HasForeignKey("UserGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SurveyAnswer");

                    b.Navigation("SurveyQuestion");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.UserMovieRating", b =>
                {
                    b.HasOne("DAL.Models.Movie", "Movie")
                        .WithMany("UserMovieRatings")
                        .HasForeignKey("MovieGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany("UserMovieRatings")
                        .HasForeignKey("UserGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.UserProfile", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.ApplicationUser", b =>
                {
                    b.Navigation("SurveyUserAnswers");

                    b.Navigation("UserMovieRatings");
                });

            modelBuilder.Entity("DAL.Models.Movie", b =>
                {
                    b.Navigation("KnowFor");

                    b.Navigation("UserMovieRatings");
                });

            modelBuilder.Entity("DAL.Models.Person", b =>
                {
                    b.Navigation("KnowFor");
                });

            modelBuilder.Entity("DAL.Models.SurveyQuestion", b =>
                {
                    b.Navigation("SurveyAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}