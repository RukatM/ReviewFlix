using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewFlixApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangesAdded3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterUrl",
                table: "Films",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterUrl",
                table: "Films");
        }
    }
}
