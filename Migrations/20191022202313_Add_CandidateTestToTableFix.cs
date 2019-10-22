using Microsoft.EntityFrameworkCore.Migrations;

namespace ReliasInterviewApi.Migrations
{
    public partial class Add_CandidateTestToTableFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTest_Candidates_CandidateId",
                table: "CandidateTest");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTestQuestions_CandidateTest_CandidateTestTestId",
                table: "CandidateTestQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateTest",
                table: "CandidateTest");

            migrationBuilder.RenameTable(
                name: "CandidateTest",
                newName: "CandidateTests");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateTest_CandidateId",
                table: "CandidateTests",
                newName: "IX_CandidateTests_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateTests",
                table: "CandidateTests",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTestQuestions_CandidateTests_CandidateTestTestId",
                table: "CandidateTestQuestions",
                column: "CandidateTestTestId",
                principalTable: "CandidateTests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTests_Candidates_CandidateId",
                table: "CandidateTests",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTestQuestions_CandidateTests_CandidateTestTestId",
                table: "CandidateTestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTests_Candidates_CandidateId",
                table: "CandidateTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateTests",
                table: "CandidateTests");

            migrationBuilder.RenameTable(
                name: "CandidateTests",
                newName: "CandidateTest");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateTests_CandidateId",
                table: "CandidateTest",
                newName: "IX_CandidateTest_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateTest",
                table: "CandidateTest",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTest_Candidates_CandidateId",
                table: "CandidateTest",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTestQuestions_CandidateTest_CandidateTestTestId",
                table: "CandidateTestQuestions",
                column: "CandidateTestTestId",
                principalTable: "CandidateTest",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
