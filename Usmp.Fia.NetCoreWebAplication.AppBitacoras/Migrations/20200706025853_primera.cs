using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Usmp.Fia.NetCoreWebAplication.AppBitacoras.Migrations
{
    public partial class primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.CreateTable(
                name: "IntegrantesPorGrupos",
                columns: table => new
                {
                    IdIntegrantesPorGrupos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idestudiante = table.Column<int>(nullable: false),
                    idgrupo = table.Column<int>(nullable: false),
                    fecha_creacion = table.Column<DateTime>(nullable: false),
                    fecha_modificacion = table.Column<DateTime>(nullable: false),
                    user_crea = table.Column<string>(nullable: false),
                    user_modif = table.Column<string>(nullable: false),
                    estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrantesPorGrupos", x => x.IdIntegrantesPorGrupos);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
