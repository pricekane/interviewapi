using Microsoft.EntityFrameworkCore.Migrations;

namespace ReliasInterviewApi.Migrations
{
    public partial class Add_CandidateTestAndTestQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateTest",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateTest", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_CandidateTest_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidateTestQuestions",
                columns: table => new
                {
                    TestQuestionsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: true),
                    CandidateTestTestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateTestQuestions", x => x.TestQuestionsId);
                    table.ForeignKey(
                        name: "FK_CandidateTestQuestions_CandidateTest_CandidateTestTestId",
                        column: x => x.CandidateTestTestId,
                        principalTable: "CandidateTest",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateTestQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTest_CandidateId",
                table: "CandidateTest",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTestQuestions_CandidateTestTestId",
                table: "CandidateTestQuestions",
                column: "CandidateTestTestId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTestQuestions_QuestionId",
                table: "CandidateTestQuestions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateTestQuestions");

            migrationBuilder.DropTable(
                name: "CandidateTest");
        }
    }
}
