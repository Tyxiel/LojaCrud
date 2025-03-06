using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaCrud.Migrations
{
    public partial class CreatingTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Produto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Produto");
        }
    }
}
