using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackingSystem.Migrations
{
    /// <inheritdoc />
    public partial class _4CommentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Works");
        }
    }
}
