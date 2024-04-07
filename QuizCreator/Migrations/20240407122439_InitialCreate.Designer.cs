﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizCreator.Models.Database;

#nullable disable

namespace QuizCreator.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20240407122439_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuizCreator.Models.Database.Answer", b =>
                {
                    b.Property<Guid>("AnswerGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Correct")
                        .HasColumnType("bit");

                    b.Property<Guid?>("QuestionGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnswerGuid");

                    b.HasIndex("QuestionGuid");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QuizCreator.Models.Database.Question", b =>
                {
                    b.Property<Guid>("QuestionGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TemplateGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionGuid");

                    b.HasIndex("TemplateGuid");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizCreator.Models.Database.Quiz", b =>
                {
                    b.Property<Guid>("QuizGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTaken")
                        .HasColumnType("datetime2");

                    b.Property<string>("Quizee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuizGuid");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuizCreator.Models.Database.Response", b =>
                {
                    b.Property<Guid>("ResponseGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswerGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("QuizGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ResponseGuid");

                    b.HasIndex("QuizGuid");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("QuizCreator.Models.Database.Template", b =>
                {
                    b.Property<Guid>("TemplateGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Public")
                        .HasColumnType("bit");

                    b.Property<string>("Quizzer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateGuid");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("QuizCreator.Models.Database.Answer", b =>
                {
                    b.HasOne("QuizCreator.Models.Database.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionGuid");
                });

            modelBuilder.Entity("QuizCreator.Models.Database.Question", b =>
                {
                    b.HasOne("QuizCreator.Models.Database.Template", null)
                        .WithMany("Questions")
                        .HasForeignKey("TemplateGuid");
                });

            modelBuilder.Entity("QuizCreator.Models.Database.Response", b =>
                {
                    b.HasOne("QuizCreator.Models.Database.Quiz", null)
                        .WithMany("Responses")
                        .HasForeignKey("QuizGuid");
                });

            modelBuilder.Entity("QuizCreator.Models.Database.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("QuizCreator.Models.Database.Quiz", b =>
                {
                    b.Navigation("Responses");
                });

            modelBuilder.Entity("QuizCreator.Models.Database.Template", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
