using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesBufa.Migrations
{
    public partial class CorrigindoCampoQuantidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidadae",
                table: "CarrinhoCompraItens",
                newName: "Quantidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "CarrinhoCompraItens",
                newName: "Quantidadae");
        }
    }
}
