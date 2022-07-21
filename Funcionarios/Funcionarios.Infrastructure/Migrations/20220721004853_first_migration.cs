using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Funcionarios.Infrastructure.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CBO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioCLT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    FuncaoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioCLT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionarioCLT_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioCLT_Funcao_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioPJ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FuncaoId = table.Column<int>(type: "int", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioPJ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionarioPJ_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuncionarioPJ_Funcao_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioCLT_CargoId",
                table: "FuncionarioCLT",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioCLT_FuncaoId",
                table: "FuncionarioCLT",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioPJ_CargoId",
                table: "FuncionarioPJ",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioPJ_FuncaoId",
                table: "FuncionarioPJ",
                column: "FuncaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioCLT");

            migrationBuilder.DropTable(
                name: "FuncionarioPJ");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Funcao");
        }
    }
}
