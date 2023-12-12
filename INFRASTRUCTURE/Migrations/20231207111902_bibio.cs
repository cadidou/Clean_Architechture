using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class bibio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adherants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero_carte = table.Column<int>(type: "int", nullable: false),
                    date_inscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nbr_emprunt = table.Column<int>(type: "int", nullable: false),
                    sanctionne = table.Column<bool>(type: "bit", nullable: false),
                    date_sanction = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adherants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ouvrages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    auteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nbr = table.Column<int>(type: "int", nullable: false),
                    consultable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ouvrages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emprunter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dateEmprunt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateRetour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdherantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OuvrageId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprunter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emprunter_adherants_AdherantId",
                        column: x => x.AdherantId,
                        principalTable: "adherants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emprunter_ouvrages_OuvrageId",
                        column: x => x.OuvrageId,
                        principalTable: "ouvrages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_emprunter_AdherantId",
                table: "emprunter",
                column: "AdherantId");

            migrationBuilder.CreateIndex(
                name: "IX_emprunter_OuvrageId",
                table: "emprunter",
                column: "OuvrageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprunter");

            migrationBuilder.DropTable(
                name: "adherants");

            migrationBuilder.DropTable(
                name: "ouvrages");
        }
    }
}
