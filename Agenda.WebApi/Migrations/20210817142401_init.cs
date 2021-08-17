using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda.WebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Bairros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Bairros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Estados", x => x.Id);
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
                name: "Tbl_Tipos_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Tipos_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Cidades_Tbl_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Tbl_Estados",
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
                        name: "FK_Tbl_Emails_Contato_Tbl_Contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Tbl_Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Enderecos_Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContato = table.Column<int>(type: "int", nullable: false),
                    ContatoId = table.Column<int>(type: "int", nullable: true),
                    IdTipoEndereco = table.Column<int>(type: "int", nullable: false),
                    TipoEnderecoId = table.Column<int>(type: "int", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BairroId = table.Column<int>(type: "int", nullable: true),
                    IdBairro = table.Column<int>(type: "int", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: true),
                    IdCidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Enderecos_Contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Enderecos_Contato_Tbl_Bairros_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Tbl_Bairros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Enderecos_Contato_Tbl_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Tbl_Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Enderecos_Contato_Tbl_Contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Tbl_Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Enderecos_Contato_Tbl_Tipos_Endereco_TipoEnderecoId",
                        column: x => x.TipoEnderecoId,
                        principalTable: "Tbl_Tipos_Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Tbl_Telefones_Contato_Tbl_Contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Tbl_Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tbl_Bairros",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "Grã-Duquesa" });

            migrationBuilder.InsertData(
                table: "Tbl_Cidades",
                columns: new[] { "Id", "EstadoId", "IdEstado", "Nome" },
                values: new object[] { 1, null, 1, "Governador Valadares" });

            migrationBuilder.InsertData(
                table: "Tbl_Estados",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[] { 1, "Minas Gerais", "MG" });

            migrationBuilder.InsertData(
                table: "Tbl_Tipos_Contato",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "CLIENTE" },
                    { 2, "OUTROS" }
                });

            migrationBuilder.InsertData(
                table: "Tbl_Tipos_Endereco",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Casa" },
                    { 2, "Trabalho" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cidades_EstadoId",
                table: "Tbl_Cidades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Contatos_TipoId",
                table: "Tbl_Contatos",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Emails_Contato_ContatoId",
                table: "Tbl_Emails_Contato",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Enderecos_Contato_BairroId",
                table: "Tbl_Enderecos_Contato",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Enderecos_Contato_CidadeId",
                table: "Tbl_Enderecos_Contato",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Enderecos_Contato_ContatoId",
                table: "Tbl_Enderecos_Contato",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Enderecos_Contato_TipoEnderecoId",
                table: "Tbl_Enderecos_Contato",
                column: "TipoEnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Telefones_Contato_ContatoId",
                table: "Tbl_Telefones_Contato",
                column: "ContatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Emails_Contato");

            migrationBuilder.DropTable(
                name: "Tbl_Enderecos_Contato");

            migrationBuilder.DropTable(
                name: "Tbl_Telefones_Contato");

            migrationBuilder.DropTable(
                name: "Tbl_Bairros");

            migrationBuilder.DropTable(
                name: "Tbl_Cidades");

            migrationBuilder.DropTable(
                name: "Tbl_Tipos_Endereco");

            migrationBuilder.DropTable(
                name: "Tbl_Contatos");

            migrationBuilder.DropTable(
                name: "Tbl_Estados");

            migrationBuilder.DropTable(
                name: "Tbl_Tipos_Contato");
        }
    }
}
