using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNet_Core_EF_CodeFirst.Migrations
{
    public partial class tablacategoriadeletecodigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigo",
                table: "categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "codigo",
                table: "categoria",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true);
        }
    }
}
