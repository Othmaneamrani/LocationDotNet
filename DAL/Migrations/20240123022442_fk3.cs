using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fk3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demandes_comptes_vehiculeId",
                table: "demandes");

            migrationBuilder.DropForeignKey(
                name: "FK_demandes_vehicules_compteId",
                table: "demandes");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demandes_comptes_compteId",
                table: "demandes");

            migrationBuilder.DropForeignKey(
                name: "FK_demandes_vehicules_vehiculeId",
                table: "demandes");

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
    }
}
