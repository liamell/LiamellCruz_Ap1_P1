using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiamellCruz_Ap1_P1.Migrations
{
    /// <inheritdoc />
    public partial class si : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeudorId",
                table: "Prestamo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeudorId",
                table: "Prestamo");
        }
    }
}
