using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionEx5Gateaux.Migrations
{
    /// <inheritdoc />
    public partial class suppUnite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unite",
                table: "Ingredient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unite",
                table: "Ingredient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
