using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieWorldcfjsProject.Migrations
{
    /// <inheritdoc />
    public partial class addcolum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Imdb",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imdb",
                table: "Movies");
        }
    }
}
