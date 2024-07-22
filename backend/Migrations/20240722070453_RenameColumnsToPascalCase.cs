using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsToPascalCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CubeId",
                table: "Cubes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CardInCubeId",
                table: "CardsInCube",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CardInArchetypeId",
                table: "CardsInArchetype",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Cards",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Cards",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "CubeName",
                table: "Cubes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CubeName",
                table: "Cubes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cubes",
                newName: "CubeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CardsInCube",
                newName: "CardInCubeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CardsInArchetype",
                newName: "CardInArchetypeId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cards",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cards",
                newName: "CardId");
        }
    }
}
