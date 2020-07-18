using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;
using System;

namespace webBancoGeneroso.Migrations
{
    public partial class ajustContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Contato_Cliente_ClienteId",
            //    table: "Contato");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Endereco_Cliente_ClienteId",
            //    table: "Endereco");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Minuta_Cliente_ClienteId",
            //    table: "Minuta");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Cliente",
            //    table: "Cliente");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    RG = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Situacao = table.Column<bool>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true),
                    TipoPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
             

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Endereco",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "DadosBancarios",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "DadosBancarios",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Agencia",
                table: "DadosBancarios",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Clientes",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Clientes_ClienteId",
                table: "Contato",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Clientes_ClienteId",
                table: "Endereco",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Minuta_Clientes_ClienteId",
                table: "Minuta",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Contato_Clientes_ClienteId",
            //    table: "Contato");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Endereco_Clientes_ClienteId",
            //    table: "Endereco");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Minuta_Clientes_ClienteId",
            //    table: "Minuta");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Clientes",
            //    table: "Clientes");

            //migrationBuilder.RenameTable(
            //    name: "Clientes",
            //    newName: "Cliente");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Cep", FK_Contato_Cliente_ClienteId
            //    table: "Endereco",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 8,
            //    oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "DadosBancarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "DadosBancarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 18);

            migrationBuilder.AlterColumn<string>(
                name: "Agencia",
                table: "DadosBancarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Cliente",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Cliente",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Cliente_ClienteId",
                table: "Contato",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_ClienteId",
                table: "Endereco",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Minuta_Cliente_ClienteId",
                table: "Minuta",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
