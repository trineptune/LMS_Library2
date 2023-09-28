using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectWebApi.Migrations
{
    /// <inheritdoc />
    public partial class updateDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "LessonsFile",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LessonsFile");
        }
    }
}
