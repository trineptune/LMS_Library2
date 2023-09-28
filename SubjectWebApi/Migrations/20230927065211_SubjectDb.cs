using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SubjectDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subjectNotifications_Subjects_SubjectId",
                table: "subjectNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subjectNotifications",
                table: "subjectNotifications");

            migrationBuilder.RenameTable(
                name: "subjectNotifications",
                newName: "SubjectNotifications");

            migrationBuilder.RenameIndex(
                name: "IX_subjectNotifications_SubjectId",
                table: "SubjectNotifications",
                newName: "IX_SubjectNotifications_SubjectId");

            migrationBuilder.RenameColumn(
                name: "answer",
                table: "Answers",
                newName: "AnswerDescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectNotifications",
                table: "SubjectNotifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectNotifications_Subjects_SubjectId",
                table: "SubjectNotifications",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectNotifications_Subjects_SubjectId",
                table: "SubjectNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectNotifications",
                table: "SubjectNotifications");

            migrationBuilder.RenameTable(
                name: "SubjectNotifications",
                newName: "subjectNotifications");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectNotifications_SubjectId",
                table: "subjectNotifications",
                newName: "IX_subjectNotifications_SubjectId");

            migrationBuilder.RenameColumn(
                name: "AnswerDescription",
                table: "Answers",
                newName: "answer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjectNotifications",
                table: "subjectNotifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_subjectNotifications_Subjects_SubjectId",
                table: "subjectNotifications",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
