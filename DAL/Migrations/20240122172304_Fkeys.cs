using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Fkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demandes_comptes_compteId",
                table: "demandes");

            migrationBuilder.DropForeignKey(
                name: "FK_demandes_vehicules_vehiculeId",
                table: "demandes");

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
                name: "favoris",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    compteId = table.Column<long>(type: "bigint", nullable: false),
                    vehiculeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favoris", x => x.id);
                    table.ForeignKey(
                        name: "FK_favoris_comptes_compteId",
                        column: x => x.compteId,
                        principalTable: "comptes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favoris_vehicules_vehiculeId",
                        column: x => x.vehiculeId,
                        principalTable: "vehicules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_favoris_compteId",
                table: "favoris",
                column: "compteId");

            migrationBuilder.CreateIndex(
                name: "IX_favoris_vehiculeId",
                table: "favoris",
                column: "vehiculeId");

            migrationBuilder.AddForeignKey(
                name: "FK_demandes_comptes_vehiculeId",
                table: "demandes",
                column: "vehiculeId",
                principalTable: "comptes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_demandes_vehicules_compteId",
                table: "demandes",
                column: "compteId",
                principalTable: "vehicules",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demandes_comptes_vehiculeId",
                table: "demandes");

            migrationBuilder.DropForeignKey(
                name: "FK_demandes_vehicules_compteId",
                table: "demandes");

            migrationBuilder.DropTable(
                name: "favoris");

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
                name: "FK_demandes_comptes_compteId",
                table: "demandes",
                column: "compteId",
                principalTable: "comptes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_demandes_vehicules_vehiculeId",
                table: "demandes",
                column: "vehiculeId",
                principalTable: "vehicules",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicules_comptes_Compteid",
                table: "vehicules",
                column: "Compteid",
                principalTable: "comptes",
                principalColumn: "id");
        }
    }
}
