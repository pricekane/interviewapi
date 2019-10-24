using Microsoft.EntityFrameworkCore.Migrations;

namespace ReliasInterviewApi.Migrations
{
    public partial class CandidateTest_AddFinished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "CandidateTests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finished",
                table: "CandidateTests");
        }
    }
}
