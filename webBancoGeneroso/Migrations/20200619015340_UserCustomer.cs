using Microsoft.EntityFrameworkCore.Migrations;

namespace webBancoGeneroso.Migrations
{
    public partial class UserCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoIdPath",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoIdPath",
                table: "AspNetUsers");
        }
    }
}
