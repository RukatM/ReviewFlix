using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewFlixApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangesAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Actors",
                newName: "Surname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Actors",
                newName: "SurName");
        }
    }
}
