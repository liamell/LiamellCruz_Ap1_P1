using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiamellCruz_Ap1_P1.Migrations
{
    /// <inheritdoc />
    public partial class Detalles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deudor",
                columns: table => new
                {
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudor", x => x.DeudorId);
                });

            migrationBuilder.CreateTable(
                name: "Cobro",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobro", x => x.CobroId);
                    table.ForeignKey(
                        name: "FK_Cobro_Deudor_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudor",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobroDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorCobrado = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobroDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_CobroDetalle_Cobro_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobro",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CobroDetalle_Prestamo_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamo",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobro_DeudorId",
                table: "Cobro",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroDetalle_CobroId",
                table: "CobroDetalle",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroDetalle_PrestamoId",
                table: "CobroDetalle",
                column: "PrestamoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobroDetalle");

            migrationBuilder.DropTable(
                name: "Cobro");

            migrationBuilder.DropTable(
                name: "Deudor");
        }
    }
}
