using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LiamellCruz_Ap1_P1.Migrations
{
    /// <inheritdoc />
    public partial class Modficacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deudor",
                table: "Prestamo");

            migrationBuilder.InsertData(
                table: "Deudor",
                columns: new[] { "DeudorId", "Nombres" },
                values: new object[,]
                {
                    { 1, "liamell Cruz" },
                    { 2, "Marcos Rosario" },
                    { 3, "Josmeyli Duarte" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_DeudorId",
                table: "Prestamo",
                column: "DeudorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Deudor_DeudorId",
                table: "Prestamo",
                column: "DeudorId",
                principalTable: "Deudor",
                principalColumn: "DeudorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Deudor_DeudorId",
                table: "Prestamo");

            migrationBuilder.DropIndex(
                name: "IX_Prestamo_DeudorId",
                table: "Prestamo");

            migrationBuilder.DeleteData(
                table: "Deudor",
                keyColumn: "DeudorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deudor",
                keyColumn: "DeudorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deudor",
                keyColumn: "DeudorId",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Deudor",
                table: "Prestamo",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
