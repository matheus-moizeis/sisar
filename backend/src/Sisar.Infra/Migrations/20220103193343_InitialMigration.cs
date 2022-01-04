using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sisar.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emitente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DtEdicao = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ativo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emitente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emitente");
        }
    }
}
