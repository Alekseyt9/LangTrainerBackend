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
    [Migration("20230324181836_m12")]
    partial class m12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LangTrainerEntity.Entities.Expression", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("Text", "LanguageId")
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

                    b.ToTable("TrainingGroups");
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

                    b.HasKey("Id");

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

                    b.Property<Guid>("PartOfSpeechId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExpressionId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PartOfSpeechId");

                    b.ToTable("Translates");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.TranslateInGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("timestamp with time zone");

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
                            PassSalt = new byte[] { 45, 62, 25, 227, 198, 240, 94, 199, 253, 1, 24, 55, 2, 192, 220, 238, 81, 249, 91, 207, 29, 73, 220, 140, 94, 189, 46, 73, 122, 236, 232, 250, 102, 143, 43, 136, 249, 102, 221, 60, 105, 245, 205, 175, 83, 189, 164, 249, 11, 150, 136, 20, 201, 232, 19, 241, 74, 77, 150, 195, 124, 84, 140, 248 },
                            PasswordHash = "8FE06B3AFC9E37893D6FA0E60AB0B712487EA602DE58BED3333F68E8B02C1AE32724C005EA0DAEA9AE0B11CEF62F06F99E10362E87E65318FA99C74C96D26574"
                        },
                        new
                        {
                            Id = new Guid("e3db5e30-1c0e-432c-920d-7160d71f8d35"),
                            Email = "alekseyt9@gmail.com",
                            Login = "test",
                            PassSalt = new byte[] { 87, 125, 99, 189, 149, 142, 6, 252, 18, 25, 224, 188, 188, 188, 150, 120, 92, 184, 149, 108, 237, 204, 144, 78, 128, 73, 210, 255, 248, 22, 226, 35, 89, 129, 204, 25, 158, 60, 168, 152, 118, 185, 207, 23, 124, 188, 30, 102, 251, 21, 48, 56, 83, 172, 151, 102, 190, 198, 69, 141, 170, 1, 13, 151 },
                            PasswordHash = "5E96EED165086C76D0F32322BCB2960B3A46627A87678BE4B3BFFCEC1926F6DE207D5C3A1CB3A62C60DC6D1B9D28BB1D9C4921B820551CA292CF221EF02B8F8B"
                        });
                });

            modelBuilder.Entity("LangTrainerModel.Entities.Lang.PartOfSpeech", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId", "Name")
                        .IsUnique();

                    b.ToTable("PartOfSpeech");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4b8b1b37-2696-466b-a053-c5a2f4f5c1a3"),
                            LanguageId = new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"),
                            Name = "noun"
                        },
                        new
                        {
                            Id = new Guid("8f281ed9-fb46-49c4-88c7-0c00d304b2cb"),
                            LanguageId = new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"),
                            Name = "pronoun"
                        },
                        new
                        {
                            Id = new Guid("fd0049c4-f203-44bf-ae8c-1679a81de1d4"),
                            LanguageId = new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"),
                            Name = "verb"
                        },
                        new
                        {
                            Id = new Guid("3ec5b5bb-baed-4135-853e-23cbf14cea68"),
                            LanguageId = new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"),
                            Name = "adjective"
                        },
                        new
                        {
                            Id = new Guid("b78304b8-70fa-475c-8898-a7d5c8f48a66"),
                            LanguageId = new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"),
                            Name = "adverb"
                        },
                        new
                        {
                            Id = new Guid("ca7cf798-0015-42b1-bf47-d450da865b75"),
                            LanguageId = new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"),
                            Name = "preposition"
                        },
                        new
                        {
                            Id = new Guid("eea3308f-90eb-43de-815f-15f3b3dc8a22"),
                            LanguageId = new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"),
                            Name = "conjunction"
                        },
                        new
                        {
                            Id = new Guid("571a9fdb-f2db-4e55-acaf-3670db7153eb"),
                            LanguageId = new Guid("2f8444bc-096b-40c4-ae15-3cc1858a0d27"),
                            Name = "interjection"
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
                        .WithMany("TrainingGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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

                    b.HasOne("LangTrainerModel.Entities.Lang.PartOfSpeech", "PartOfSpeech")
                        .WithMany()
                        .HasForeignKey("PartOfSpeechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expression");

                    b.Navigation("Language");

                    b.Navigation("PartOfSpeech");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.TranslateInGroup", b =>
                {
                    b.HasOne("LangTrainerEntity.Entities.TrainingGroup", "Group")
                        .WithMany("Translates")
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

            modelBuilder.Entity("LangTrainerModel.Entities.Lang.PartOfSpeech", b =>
                {
                    b.HasOne("LangTrainerEntity.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
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

            modelBuilder.Entity("LangTrainerEntity.Entities.TrainingGroup", b =>
                {
                    b.Navigation("Translates");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.Translate", b =>
                {
                    b.Navigation("Samples");
                });

            modelBuilder.Entity("LangTrainerEntity.Entities.User", b =>
                {
                    b.Navigation("TrainingGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
