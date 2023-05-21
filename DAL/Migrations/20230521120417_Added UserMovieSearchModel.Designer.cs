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
    [Migration("20230521120417_Added UserMovieSearchModel")]
    partial class AddedUserMovieSearchModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.AlgorithmChange", b =>
                {
                    b.Property<Guid>("AlgorithmChangeGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlgorithmName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AlgorithmChangeGuid");

                    b.ToTable("AlgorithmChanges");
                });

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

            modelBuilder.Entity("DAL.Models.Recommendation", b =>
                {
                    b.Property<Guid>("RecommendationGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLiked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LikedDecisionDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MovieGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserGUID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RecommendationGUID");

                    b.HasIndex("MovieGUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("Recommendations");
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

            modelBuilder.Entity("DAL.Models.UserMovieSearch", b =>
                {
                    b.Property<Guid>("UserMovieSearchGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MovieGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserGUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserMovieSearchGUID");

                    b.HasIndex("MovieGUID");

                    b.HasIndex("UserGUID");

                    b.ToTable("UserMovieSearches");
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

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("DAL.Models.Recommendation", b =>
                {
                    b.HasOne("DAL.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieGUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserGUID");

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

            modelBuilder.Entity("DAL.Models.UserMovieSearch", b =>
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
