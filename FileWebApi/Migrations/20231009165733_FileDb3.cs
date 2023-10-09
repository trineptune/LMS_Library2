using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileWebApi.Migrations
{
    /// <inheritdoc />
    public partial class FileDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "ResoureFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "ResoureFiles");
        }
    }
}
