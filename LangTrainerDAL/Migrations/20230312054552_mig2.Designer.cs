﻿// <auto-generated />
using System;
using LangTrainerDAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LangTrainerDAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230312054552_mig2")]
    partial class mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LangTrainerEntity.Entities.Expression", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uuid");

                    b.Property<string>("PartOfSpeech")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("Text", "PartOfSpeech", "LanguageId")
                        .IsUnique();

                    b.ToTable("Expressions");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("29425483-c990-4ec9-9f1e-4658eed1cad2"),
                            Name = "russian"
                        },
                        new
                        {
                            Id = new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"),
                            Name = "english"
                        },
                        new
                        {
                            Id = new Guid("4c2916c7-e10e-4579-91c6-39c37965ddb1"),
                            Name = "french"
                        },
                        new
                        {
                            Id = new Guid("ee8f502d-437c-4378-a1a2-e5d7a3b3b29e"),
                            Name = "german"
                        },
                        new
                        {
                            Id = new Guid("e52926ee-64f1-4b04-8a7e-187c5d0213c8"),
                            Name = "italian"
                        },
                        new
                        {
                            Id = new Guid("04dbc458-0835-47f2-8140-432376686536"),
                            Name = "spanish"
                        });
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Sample", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TranslateId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TranslateId");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Sound", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<Guid>("ExpressionId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Hash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExpressionId");

                    b.ToTable("Sound");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.TrainingGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TrainingGroup");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.TrainingInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("LastSuccessTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Stage")
                        .HasColumnType("integer");

                    b.Property<Guid>("TranslateInGroupId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TranslateInGroupId");

                    b.ToTable("TrainingInfo");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Translate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ExpressionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExpressionId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Translate");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.TranslateInGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TrainingInfoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TranslateId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TrainingInfoId");

                    b.HasIndex("TranslateId");

                    b.ToTable("TranslateInGroup");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PassSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("98d48c5d-a10f-4704-9c08-949fe791cf4d"),
                            Email = "-",
                            Login = "admin",
                            PassSalt = new byte[] { 109, 191, 56, 3, 57, 130, 31, 82, 181, 206, 66, 42, 194, 139, 30, 74, 54, 74, 203, 1, 174, 33, 102, 166, 30, 127, 11, 167, 199, 100, 108, 55, 248, 213, 210, 76, 149, 22, 247, 58, 190, 225, 189, 75, 150, 87, 56, 77, 46, 208, 80, 39, 4, 46, 239, 7, 153, 88, 193, 150, 91, 26, 19, 70 },
                            PasswordHash = "D87ADB03DFA1EB67BDCED794B522FED629DCE6BA4015BBCE8E3A545502C5BAA6E1552E62A884A9B76913B96FC249A6FE63786FA404C3FBC7DA5D7DCF9571962D"
                        });
                });

            modelBuilder.Entity("LangTrainerModel.Entities.Training.UserSettings", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Expression", b =>
                {
                    b.HasOne("LangTrainerEntity.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Sample", b =>
                {
                    b.HasOne("LangTrainerEntity.Entities.Translate", "Translate")
                        .WithMany("Samples")
                        .HasForeignKey("TranslateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Translate");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Sound", b =>
                {
                    b.HasOne("LangTrainerEntity.Entities.Expression", "Expression")
                        .WithMany("Sounds")
                        .HasForeignKey("ExpressionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expression");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.TrainingGroup", b =>
                {
                    b.HasOne("LangTrainerEntity.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.TrainingInfo", b =>
                {
                    b.HasOne("LangTrainerEntity.Entities.TranslateInGroup", "TranslateInGroup")
                        .WithMany()
                        .HasForeignKey("TranslateInGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TranslateInGroup");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Translate", b =>
                {
                    b.HasOne("LangTrainerEntity.Entities.Expression", "Expression")
                        .WithMany("Translates")
                        .HasForeignKey("ExpressionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LangTrainerEntity.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expression");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.TranslateInGroup", b =>
                {
                    b.HasOne("LangTrainerEntity.Entities.TrainingGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LangTrainerEntity.Entities.TrainingInfo", "TrainingInfo")
                        .WithMany()
                        .HasForeignKey("TrainingInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LangTrainerEntity.Entities.Translate", "Translate")
                        .WithMany()
                        .HasForeignKey("TranslateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("TrainingInfo");

                    b.Navigation("Translate");
                });

            modelBuilder.Entity("LangTrainerModel.Entities.Training.UserSettings", b =>
                {
                    b.HasOne("LangTrainerEntity.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Expression", b =>
                {
                    b.Navigation("Sounds");

                    b.Navigation("Translates");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Translate", b =>
                {
                    b.Navigation("Samples");
                });
#pragma warning restore 612, 618
        }
    }
}
