using Microsoft.EntityFrameworkCore.Migrations;

namespace ReliasInterviewApi.Migrations
{
    public partial class CandidateTest_CandidateIdPropertyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTests_Candidates_CandidateId",
                table: "CandidateTests");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "CandidateTests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTests_Candidates_CandidateId",
                table: "CandidateTests",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTests_Candidates_CandidateId",
                table: "CandidateTests");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "CandidateTests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTests_Candidates_CandidateId",
                table: "CandidateTests",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
