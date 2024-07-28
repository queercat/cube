using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RemovesIndirectionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardsInCube");

            migrationBuilder.AddColumn<int>(
                name: "CubeId",
                table: "Cards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CubeId",
                table: "Cards",
                column: "CubeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Cubes_CubeId",
                table: "Cards",
                column: "CubeId",
                principalTable: "Cubes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Cubes_CubeId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CubeId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CubeId",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "CardsInCube",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    CubeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardsInCube", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardsInCube_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardsInCube_Cubes_CubeId",
                        column: x => x.CubeId,
                        principalTable: "Cubes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardsInCube_CardId",
                table: "CardsInCube",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardsInCube_CubeId",
                table: "CardsInCube",
                column: "CubeId");
        }
    }
}
