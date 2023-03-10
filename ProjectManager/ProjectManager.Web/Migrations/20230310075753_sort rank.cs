using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Web.Migrations
{
    /// <inheritdoc />
    public partial class sortrank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortRank",
                table: "TimelineItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortRank",
                table: "TimelineGroups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortRank",
                table: "TimelineItems");

            migrationBuilder.DropColumn(
                name: "SortRank",
                table: "TimelineGroups");
        }
    }
}
