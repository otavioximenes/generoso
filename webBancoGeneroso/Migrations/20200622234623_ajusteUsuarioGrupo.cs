using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace webBancoGeneroso.Migrations
{
    public partial class ajusteUsuarioGrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarioSistemas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    PathPhoto = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioSistemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioGruposAcessos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdUsuarioSistema = table.Column<long>(nullable: false),
                    UsuarioSistemaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioGruposAcessos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioGruposAcessos_usuarioSistemas_UsuarioSistemaId",
                        column: x => x.UsuarioSistemaId,
                        principalTable: "usuarioSistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gruposAcessos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PageAcesso = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    UsuarioGruposAcessoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gruposAcessos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gruposAcessos_UsuarioGruposAcessos_UsuarioGruposAcessoId",
                        column: x => x.UsuarioGruposAcessoId,
                        principalTable: "UsuarioGruposAcessos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gruposAcessos_UsuarioGruposAcessoId",
                table: "gruposAcessos",
                column: "UsuarioGruposAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGruposAcessos_UsuarioSistemaId",
                table: "UsuarioGruposAcessos",
                column: "UsuarioSistemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gruposAcessos");

            migrationBuilder.DropTable(
                name: "UsuarioGruposAcessos");

            migrationBuilder.DropTable(
                name: "usuarioSistemas");
        }
    }
}
