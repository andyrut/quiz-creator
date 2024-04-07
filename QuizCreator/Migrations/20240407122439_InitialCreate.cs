using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizCreator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quizee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizGuid);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    TemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quizzer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Public = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.TemplateGuid);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseGuid);
                    table.ForeignKey(
                        name: "FK_Responses_Quizzes_QuizGuid",
                        column: x => x.QuizGuid,
                        principalTable: "Quizzes",
                        principalColumn: "QuizGuid");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionGuid);
                    table.ForeignKey(
                        name: "FK_Questions_Templates_TemplateGuid",
                        column: x => x.TemplateGuid,
                        principalTable: "Templates",
                        principalColumn: "TemplateGuid");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Correct = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerGuid);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionGuid",
                        column: x => x.QuestionGuid,
                        principalTable: "Questions",
                        principalColumn: "QuestionGuid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionGuid",
                table: "Answers",
                column: "QuestionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TemplateGuid",
                table: "Questions",
                column: "TemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuizGuid",
                table: "Responses",
                column: "QuizGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
