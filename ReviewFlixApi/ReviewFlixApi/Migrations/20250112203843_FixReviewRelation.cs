using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewFlixApi.Migrations
{
    /// <inheritdoc />
    public partial class FixReviewRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Films_FilmId1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_FilmId1",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "FilmId1",
                table: "Reviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmId1",
                table: "Reviews",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FilmId1",
                table: "Reviews",
                column: "FilmId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Films_FilmId1",
                table: "Reviews",
                column: "FilmId1",
                principalTable: "Films",
                principalColumn: "Id");
        }
    }
}
