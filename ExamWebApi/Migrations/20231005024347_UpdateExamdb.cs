using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExamdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "EssayExams");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ExamAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EssayAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EssayId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssayAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EssayAnswers_EssayExams_EssayId",
                        column: x => x.EssayId,
                        principalTable: "EssayExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EssayAnswers_EssayId",
                table: "EssayAnswers",
                column: "EssayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EssayAnswers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExamAnswers");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "EssayExams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
