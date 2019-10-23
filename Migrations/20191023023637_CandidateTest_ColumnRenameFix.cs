using Microsoft.EntityFrameworkCore.Migrations;

namespace ReliasInterviewApi.Migrations
{
    public partial class CandidateTest_ColumnRenameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTestQuestions_CandidateTests_CandidateTestTestId",
                table: "CandidateTestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTestQuestions_Questions_QuestionId",
                table: "CandidateTestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_CandidateTestQuestions_CandidateTestTestId",
                table: "CandidateTestQuestions");

            migrationBuilder.DropColumn(
                name: "CandidateTestTestId",
                table: "CandidateTestQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "CandidateTestQuestions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "CandidateTestQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTestQuestions_TestId",
                table: "CandidateTestQuestions",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTestQuestions_Questions_QuestionId",
                table: "CandidateTestQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTestQuestions_CandidateTests_TestId",
                table: "CandidateTestQuestions",
                column: "TestId",
                principalTable: "CandidateTests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTestQuestions_Questions_QuestionId",
                table: "CandidateTestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTestQuestions_CandidateTests_TestId",
                table: "CandidateTestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_CandidateTestQuestions_TestId",
                table: "CandidateTestQuestions");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "CandidateTestQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "CandidateTestQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CandidateTestTestId",
                table: "CandidateTestQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTestQuestions_CandidateTestTestId",
                table: "CandidateTestQuestions",
                column: "CandidateTestTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTestQuestions_CandidateTests_CandidateTestTestId",
                table: "CandidateTestQuestions",
                column: "CandidateTestTestId",
                principalTable: "CandidateTests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTestQuestions_Questions_QuestionId",
                table: "CandidateTestQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
