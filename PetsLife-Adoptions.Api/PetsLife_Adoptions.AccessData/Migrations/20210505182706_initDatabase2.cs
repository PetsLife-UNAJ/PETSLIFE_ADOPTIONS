using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessData.Migrations
{
    public partial class initDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adoptado",
                table: "AdoptanteMascotas");

            migrationBuilder.AddColumn<bool>(
                name: "Adoptado",
                table: "Mascotas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adoptado",
                table: "Mascotas");

            migrationBuilder.AddColumn<bool>(
                name: "Adoptado",
                table: "AdoptanteMascotas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
