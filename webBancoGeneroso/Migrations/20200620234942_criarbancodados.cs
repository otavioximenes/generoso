using Microsoft.EntityFrameworkCore.Migrations;

namespace webBancoGeneroso.Migrations
{
    public partial class criarbancodados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {               
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_ClienteId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "PhotoIdPath",
                table: "AspNetUsers");
             
            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_ClienteId",
                table: "Contatos",
                column: "ClienteId",
                unique: true);
        }
    }
}
