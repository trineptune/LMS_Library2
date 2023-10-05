using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExamdb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "ExamContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "EssayExams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "ExamContents");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "EssayExams");
        }
    }
}
