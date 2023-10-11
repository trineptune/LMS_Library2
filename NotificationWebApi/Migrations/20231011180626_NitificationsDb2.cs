using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationWebApi.Migrations
{
    /// <inheritdoc />
    public partial class NitificationsDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Check",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Check",
                table: "Notifications");
        }
    }
}
