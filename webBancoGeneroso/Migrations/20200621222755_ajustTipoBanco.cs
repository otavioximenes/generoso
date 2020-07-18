using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace webBancoGeneroso.Migrations
{
    public partial class ajustTipoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {   

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Minuta_Clientes_ClienteId",
            //    table: "Minuta");

            //migrationBuilder.DropTable(
            //    name: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposBancos",
                table: "TiposBancos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos"); 

            //migrationBuilder.RenameTable(
            //    name: "Contatos",
            //    newName: "Contato");
             
            //migrationBuilder.RenameIndex(
            //    name: "IX_Contatos_ClienteId",
            //    table: "Contato",
            //    newName: "IX_Contato_ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "TiposBancos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TiposBancos",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposBancos",
                table: "TiposBancos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contato",
                table: "Contato",
                column: "Id");

            //migrationBuilder.CreateTable(
            //    name: "Cliente",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //        Nome = table.Column<string>(maxLength: 20, nullable: false),
            //        RG = table.Column<string>(nullable: true),
            //        CPF = table.Column<string>(nullable: false),
            //        Email = table.Column<string>(nullable: false),
            //        DataNascimento = table.Column<DateTime>(nullable: false),
            //        Telefone = table.Column<string>(nullable: true),
            //        Celular = table.Column<string>(nullable: true),
            //        Situacao = table.Column<bool>(nullable: false),
            //        Observacoes = table.Column<string>(nullable: true),
            //        TipoPessoa = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cliente", x => x.Id);
            //    });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Contato_Cliente_ClienteId",
            //    table: "Contato",
            //    column: "ClienteId",
            //    principalTable: "Cliente",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
             

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Endereco_Cliente_ClienteId",
            //    table: "Endereco",
            //    column: "ClienteId",
            //    principalTable: "Cliente",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Minuta_Cliente_ClienteId",
            //    table: "Minuta",
            //    column: "ClienteId",
            //    principalTable: "Cliente",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Cliente_ClienteId",
                table: "Contato");

            migrationBuilder.DropForeignKey(
                name: "FK_DadosBancarios_TiposBancos_TiposBancosId",
                table: "DadosBancarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_ClienteId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Minuta_Cliente_ClienteId",
                table: "Minuta");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposBancos",
                table: "TiposBancos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contato",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TiposBancos");

            //migrationBuilder.RenameTable(
            //    name: "Endereco",
            //    newName: "Enderecos");

            //migrationBuilder.RenameTable(
            //    name: "Contato",
            //    newName: "Contatos");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Contato_ClienteId",
            //    table: "Contatos",
            //    newName: "IX_Contatos_ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "TiposBancos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposBancos",
                table: "TiposBancos",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos",
                column: "Id");

            //migrationBuilder.CreateTable(
            //    name: "Clientes",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //        CPF = table.Column<string>(type: "text", nullable: false),
            //        Celular = table.Column<string>(type: "text", nullable: true),
            //        DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Email = table.Column<string>(type: "text", nullable: false),
            //        Nome = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
            //        Observacoes = table.Column<string>(type: "text", nullable: true),
            //        RG = table.Column<string>(type: "text", nullable: true),
            //        Situacao = table.Column<short>(type: "bit", nullable: false),
            //        Telefone = table.Column<string>(type: "text", nullable: true),
            //        TipoPessoa = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Clientes", x => x.Id);
            //    });
             
            //migrationBuilder.AddForeignKey(
            //    name: "FK_DadosBancarios_TiposBancos_TiposBancosId",
            //    table: "DadosBancarios",
            //    column: "TiposBancosId",
            //    principalTable: "TiposBancos",
            //    principalColumn: "Codigo",
            //    onDelete: ReferentialAction.Cascade);
             
        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Minuta_Clientes_ClienteId",
        //        table: "Minuta",
        //        column: "ClienteId",
        //        principalTable: "Clientes",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.Cascade);
        }
    }
}
