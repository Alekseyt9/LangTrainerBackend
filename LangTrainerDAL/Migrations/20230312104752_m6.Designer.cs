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
    [Migration("20230312104752_m6")]
    partial class m6
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

                    b.Property<Guid>("PartOfSpeechId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExpressionId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PartOfSpeechId");

                    b.ToTable("Translate");
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
                            PassSalt = new byte[] { 170, 78, 229, 123, 3, 101, 81, 213, 56, 79, 84, 232, 27, 240, 71, 183, 54, 74, 9, 43, 96, 3, 151, 222, 159, 115, 237, 43, 115, 143, 239, 177, 117, 86, 1, 222, 235, 140, 169, 181, 54, 95, 133, 12, 58, 199, 67, 25, 239, 124, 64, 9, 9, 125, 87, 253, 110, 21, 12, 100, 106, 70, 193, 102 },
                            PasswordHash = "551466C676AD62E66F82C26B7A87A75632B9E0181839649023A3F37D6BB2AF761851DC0CF837FB15C8BEC2E4686BE7FE8E7AE6CDB361FD1FF495C83FD11C4EC7"
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

            modelBuilder.Entity("LangTrainerEntity.Entities.Translate", b =>
                {
                    b.Navigation("Samples");
                });
#pragma warning restore 612, 618
        }
    }
}
