using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class log : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demandes_clients_clientId",
                table: "demandes");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.AlterColumn<string>(
                name: "typeMoteur",
                table: "vehicules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "Compteid",
                table: "vehicules",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "comptes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comptes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehicules_Compteid",
                table: "vehicules",
                column: "Compteid");

            migrationBuilder.AddForeignKey(
                name: "FK_demandes_comptes_clientId",
                table: "demandes",
                column: "clientId",
                principalTable: "comptes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicules_comptes_Compteid",
                table: "vehicules",
                column: "Compteid",
                principalTable: "comptes",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demandes_comptes_clientId",
                table: "demandes");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicules_comptes_Compteid",
                table: "vehicules");

            migrationBuilder.DropTable(
                name: "comptes");

            migrationBuilder.DropIndex(
                name: "IX_vehicules_Compteid",
                table: "vehicules");

            migrationBuilder.DropColumn(
                name: "Compteid",
                table: "vehicules");

            migrationBuilder.AlterColumn<string>(
                name: "typeMoteur",
                table: "vehicules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    age = table.Column<int>(type: "int", nullable: false),
                    cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_demandes_clients_clientId",
                table: "demandes",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
