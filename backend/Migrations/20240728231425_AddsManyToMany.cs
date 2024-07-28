using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddsManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CardCube",
                columns: table => new
                {
                    CardsId = table.Column<int>(type: "INTEGER", nullable: false),
                    CubesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCube", x => new { x.CardsId, x.CubesId });
                    table.ForeignKey(
                        name: "FK_CardCube_Cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardCube_Cubes_CubesId",
                        column: x => x.CubesId,
                        principalTable: "Cubes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardCube_CubesId",
                table: "CardCube",
                column: "CubesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardCube");

            migrationBuilder.AddColumn<int>(
                name: "CubeId",
                table: "Cards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CubeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CubeId",
                value: null);

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
    }
}
