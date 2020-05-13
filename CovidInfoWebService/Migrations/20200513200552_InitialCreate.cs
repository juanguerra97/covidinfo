using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidInfoWebService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CasosCovid",
                columns: table => new
                {
                    CasoCovidId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pais = table.Column<string>(maxLength: 128, nullable: false),
                    Departamento = table.Column<string>(maxLength: 128, nullable: false),
                    Municipio = table.Column<string>(maxLength: 128, nullable: false),
                    PrimerNombre = table.Column<string>(maxLength: 64, nullable: false),
                    SegundoNombre = table.Column<string>(maxLength: 64, nullable: true),
                    PrimerApellido = table.Column<string>(maxLength: 64, nullable: false),
                    SegundoApellido = table.Column<string>(maxLength: 64, nullable: true),
                    Edad = table.Column<byte>(nullable: false),
                    Sexo = table.Column<char>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasosCovid", x => x.CasoCovidId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasosCovid");
        }
    }
}
