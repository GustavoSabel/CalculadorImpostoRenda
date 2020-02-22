using Microsoft.EntityFrameworkCore.Migrations;

namespace CalculadorImpostoRenda.infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contribuintes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 300, nullable: false),
                    CPF = table.Column<string>(maxLength: 14, nullable: false),
                    NumeroDependentes = table.Column<int>(nullable: false),
                    RendaMensalBruta = table.Column<decimal>(nullable: false),
                    ImpostoRenda = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuintes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contribuintes",
                columns: new[] { "Id", "CPF", "ImpostoRenda", "Nome", "NumeroDependentes", "RendaMensalBruta" },
                values: new object[] { 1, "20137334028", null, "Gustavo Sabel", 1, 2500m });

            migrationBuilder.CreateIndex(
                name: "IX_Contribuintes_CPF",
                table: "Contribuintes",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contribuintes");
        }
    }
}
