using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class compte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demandes_comptes_clientId",
                table: "demandes");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "demandes",
                newName: "compteId");

            migrationBuilder.RenameIndex(
                name: "IX_demandes_clientId",
                table: "demandes",
                newName: "IX_demandes_compteId");

            migrationBuilder.AddForeignKey(
                name: "FK_demandes_comptes_compteId",
                table: "demandes",
                column: "compteId",
                principalTable: "comptes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demandes_comptes_compteId",
                table: "demandes");

            migrationBuilder.RenameColumn(
                name: "compteId",
                table: "demandes",
                newName: "clientId");

            migrationBuilder.RenameIndex(
                name: "IX_demandes_compteId",
                table: "demandes",
                newName: "IX_demandes_clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_demandes_comptes_clientId",
                table: "demandes",
                column: "clientId",
                principalTable: "comptes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
