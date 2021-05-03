using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessData.Migrations
{
    public partial class initDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Mascotas_AnimalId",
                table: "Mascotas");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_AnimalId",
                table: "Mascotas",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Mascotas_AnimalId",
                table: "Mascotas");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_AnimalId",
                table: "Mascotas",
                column: "AnimalId",
                unique: true);
        }
    }
}
