﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNet_Core_EF_CodeFirst.Migrations
{
    public partial class tablacategoriacodigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "codigo",
                table: "categoria",
                unicode: false,
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigo",
                table: "categoria");
        }
    }
}
