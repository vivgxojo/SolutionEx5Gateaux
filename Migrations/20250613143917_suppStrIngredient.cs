using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionEx5Gateaux.Migrations
{
    /// <inheritdoc />
    public partial class suppStrIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Gateau");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Gateau",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
