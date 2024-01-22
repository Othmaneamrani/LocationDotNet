using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicules_comptes_Compteid",
                table: "vehicules");

            migrationBuilder.DropIndex(
                name: "IX_vehicules_Compteid",
                table: "vehicules");

            migrationBuilder.DropColumn(
                name: "Compteid",
                table: "vehicules");

            migrationBuilder.CreateTable(
                name: "Favoris",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    compteId = table.Column<long>(type: "bigint", nullable: false),
                    vehiculeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoris", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favoris_comptes_compteId",
                        column: x => x.compteId,
                        principalTable: "comptes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoris_vehicules_vehiculeId",
                        column: x => x.vehiculeId,
                        principalTable: "vehicules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_compteId",
                table: "Favoris",
                column: "compteId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_vehiculeId",
                table: "Favoris",
                column: "vehiculeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoris");

            migrationBuilder.AddColumn<long>(
                name: "Compteid",
                table: "vehicules",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicules_Compteid",
                table: "vehicules",
                column: "Compteid");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicules_comptes_Compteid",
                table: "vehicules",
                column: "Compteid",
                principalTable: "comptes",
                principalColumn: "id");
        }
    }
}
