using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackingSystem.Migrations
{
    /// <inheritdoc />
    public partial class _3WorkModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsCompleted",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsRead",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Works");
        }
    }
}
