using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace webBancoGeneroso.Migrations
{
    public partial class TiposBancosDadosMinuta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Minuta",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: false),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Adm = table.Column<int>(nullable: false),
                    ValorAdmin = table.Column<decimal>(nullable: false),
                    ClienteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minuta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minuta_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposBancos",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposBancos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "DadosBancarios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TiposBancosId = table.Column<int>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false),
                    Agencia = table.Column<string>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 20, nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBancarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosBancarios_TiposBancos_TiposBancosId",
                        column: x => x.TiposBancosId,
                        principalTable: "TiposBancos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosBancarios_TiposBancosId",
                table: "DadosBancarios",
                column: "TiposBancosId");

            migrationBuilder.CreateIndex(
                name: "IX_Minuta_ClienteId",
                table: "Minuta",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosBancarios");

            migrationBuilder.DropTable(
                name: "Minuta");

            migrationBuilder.DropTable(
                name: "TiposBancos");
        }
    }
}
