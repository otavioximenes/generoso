using Microsoft.EntityFrameworkCore.Migrations;

namespace webBancoGeneroso.Migrations
{
    public partial class ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Clientes",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Clientes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }
    }
}
