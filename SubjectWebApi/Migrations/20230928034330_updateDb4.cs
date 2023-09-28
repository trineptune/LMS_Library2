using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectWebApi.Migrations
{
    /// <inheritdoc />
    public partial class updateDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonsFile_Lessons_LessionId",
                table: "LessonsFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonsFile",
                table: "LessonsFile");

            migrationBuilder.RenameTable(
                name: "LessonsFile",
                newName: "ResourcesFiles");

            migrationBuilder.RenameIndex(
                name: "IX_LessonsFile_LessionId",
                table: "ResourcesFiles",
                newName: "IX_ResourcesFiles_LessionId");

            migrationBuilder.AddColumn<bool>(
                name: "Approve",
                table: "Lessons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ResourcesFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourcesFiles",
                table: "ResourcesFiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Classs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    Subjectid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Classs_Subjects_Subjectid",
                        column: x => x.Subjectid,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classs_Subjectid",
                table: "Classs",
                column: "Subjectid");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourcesFiles_Lessons_LessionId",
                table: "ResourcesFiles",
                column: "LessionId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourcesFiles_Lessons_LessionId",
                table: "ResourcesFiles");

            migrationBuilder.DropTable(
                name: "Classs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourcesFiles",
                table: "ResourcesFiles");

            migrationBuilder.DropColumn(
                name: "Approve",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ResourcesFiles");

            migrationBuilder.RenameTable(
                name: "ResourcesFiles",
                newName: "LessonsFile");

            migrationBuilder.RenameIndex(
                name: "IX_ResourcesFiles_LessionId",
                table: "LessonsFile",
                newName: "IX_LessonsFile_LessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonsFile",
                table: "LessonsFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonsFile_Lessons_LessionId",
                table: "LessonsFile",
                column: "LessionId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
