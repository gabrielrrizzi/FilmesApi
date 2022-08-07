using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesApi.Migrations
{
    public partial class Criandocadastrousuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "classificacaoEtaria",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "classificacaoEtaria",
                table: "Filmes");
        }
    }
}
