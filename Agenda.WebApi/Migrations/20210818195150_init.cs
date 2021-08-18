using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda.WebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Emails_Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContato = table.Column<int>(type: "int", nullable: false),
                    ContatoId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Emails_Contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Emails_Contato_Tbl_Emails_Contato_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Tbl_Emails_Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Tipos_Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Tipos_Contato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Telefones_Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContato = table.Column<int>(type: "int", nullable: false),
                    ContatoId = table.Column<int>(type: "int", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    IsFax = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Telefones_Contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Telefones_Contato_Tbl_Emails_Contato_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Tbl_Emails_Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    IdTipoContato = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataAniversario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomePage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Contatos_Tbl_Tipos_Contato_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tbl_Tipos_Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Contatos_TipoId",
                table: "Tbl_Contatos",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Emails_Contato_ContatoId",
                table: "Tbl_Emails_Contato",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Telefones_Contato_ContatoId",
                table: "Tbl_Telefones_Contato",
                column: "ContatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Contatos");

            migrationBuilder.DropTable(
                name: "Tbl_Telefones_Contato");

            migrationBuilder.DropTable(
                name: "Tbl_Tipos_Contato");

            migrationBuilder.DropTable(
                name: "Tbl_Emails_Contato");
        }
    }
}
