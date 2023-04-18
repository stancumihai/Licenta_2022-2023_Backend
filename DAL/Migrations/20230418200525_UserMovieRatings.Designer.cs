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
    [Migration("20230418200525_UserMovieRatings")]
    partial class UserMovieRatings
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
                            SurveyAnswerGUID = new Guid("4bb0cb91-d1d9-4625-9229-7f35c849dd66"),
                            SurveyQuestionGUID = new Guid("96da0d84-f192-469e-b71c-f9658960a601"),
                            Value = "Extremely often"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("d618d73e-4aeb-4ca4-879d-df9ba1939248"),
                            SurveyQuestionGUID = new Guid("96da0d84-f192-469e-b71c-f9658960a601"),
                            Value = "Very often"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("2d5c0672-c6a6-44ee-9b22-aba07e6b1c30"),
                            SurveyQuestionGUID = new Guid("96da0d84-f192-469e-b71c-f9658960a601"),
                            Value = "Moderately often"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("901c164f-b747-450f-9218-91ea61385ef2"),
                            SurveyQuestionGUID = new Guid("96da0d84-f192-469e-b71c-f9658960a601"),
                            Value = "Slightly often"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("68a946dd-3a1a-4b0b-9a60-d2709904223f"),
                            SurveyQuestionGUID = new Guid("96da0d84-f192-469e-b71c-f9658960a601"),
                            Value = "Not at all often"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("7673ebd4-1360-4dd9-8ba5-fb6174a18161"),
                            SurveyQuestionGUID = new Guid("1cb68441-8f10-4855-b2be-ef5e5f12760b"),
                            Value = ""
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("586a009e-d4e4-42bd-94d7-547a613d143c"),
                            SurveyQuestionGUID = new Guid("5db8e0ab-ffaa-45e5-af7b-0dcb0206f642"),
                            Value = ""
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("29a484e0-7311-45c8-a384-aedaf1106871"),
                            SurveyQuestionGUID = new Guid("3ce0f0a8-ab6b-4642-85f6-2d6182e35447"),
                            Value = ""
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("d326ea60-a907-4975-92af-a6602f16a1b4"),
                            SurveyQuestionGUID = new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"),
                            Value = "Horror"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("91d35212-1387-4d5f-be84-838ea568b3e3"),
                            SurveyQuestionGUID = new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"),
                            Value = "Romance"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("43aa1f81-6382-4bd2-a893-02d65f78a910"),
                            SurveyQuestionGUID = new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"),
                            Value = "Action/Adventure"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("5f21101b-5124-484b-8d64-05f865907012"),
                            SurveyQuestionGUID = new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"),
                            Value = "Thriller"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("8ed7b0c2-d757-42d3-b164-ddf3cc3ec2ab"),
                            SurveyQuestionGUID = new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"),
                            Value = "Science-Fiction"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("69544180-dd55-406f-ba6a-4a3cf8ac5704"),
                            SurveyQuestionGUID = new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"),
                            Value = "Comedy"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("57d011ec-4cde-466b-ad58-f27d0a325573"),
                            SurveyQuestionGUID = new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"),
                            Value = "Drama"
                        },
                        new
                        {
                            SurveyAnswerGUID = new Guid("9a62dcb1-340d-4dfd-a429-f4890db77ee2"),
                            SurveyQuestionGUID = new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"),
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
                            SurveyQuestionGUID = new Guid("96da0d84-f192-469e-b71c-f9658960a601"),
                            Category = 3,
                            Value = "1.How frequently do you watch movies?"
                        },
                        new
                        {
                            SurveyQuestionGUID = new Guid("1cb68441-8f10-4855-b2be-ef5e5f12760b"),
                            Category = 0,
                            Value = "2.Out of all the movies you have ever seen, which is your most favourite?"
                        },
                        new
                        {
                            SurveyQuestionGUID = new Guid("5db8e0ab-ffaa-45e5-af7b-0dcb0206f642"),
                            Category = 1,
                            Value = "3.Who is your favourite actor?"
                        },
                        new
                        {
                            SurveyQuestionGUID = new Guid("3ce0f0a8-ab6b-4642-85f6-2d6182e35447"),
                            Category = 2,
                            Value = "4.Who is your favourite director?"
                        },
                        new
                        {
                            SurveyQuestionGUID = new Guid("5984697a-f58d-466c-bb4f-2f95c1846037"),
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
