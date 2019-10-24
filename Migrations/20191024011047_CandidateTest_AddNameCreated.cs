using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReliasInterviewApi.Migrations
{
    public partial class CandidateTest_AddNameCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "CandidateTests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CandidateTests",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "CandidateTests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CandidateTests");
        }
    }
}
