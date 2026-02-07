using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservAR.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class updaterelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atributos_Canchas_IdCancha",
                table: "Atributos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Complejos_IdComplejo",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_IdComplejo",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Atributos_IdCancha",
                table: "Atributos");

            migrationBuilder.DropColumn(
                name: "IdComplejo",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "IdCancha",
                table: "Atributos");

            migrationBuilder.CreateTable(
                name: "AtributoCanchas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCancha = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAtributo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributoCanchas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtributoCanchas_Atributos_IdAtributo",
                        column: x => x.IdAtributo,
                        principalTable: "Atributos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtributoCanchas_Canchas_IdCancha",
                        column: x => x.IdCancha,
                        principalTable: "Canchas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosComplejo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdComplejo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdServicio = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosComplejo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiciosComplejo_Complejos_IdComplejo",
                        column: x => x.IdComplejo,
                        principalTable: "Complejos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciosComplejo_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtributoCanchas_IdAtributo",
                table: "AtributoCanchas",
                column: "IdAtributo");

            migrationBuilder.CreateIndex(
                name: "IX_AtributoCanchas_IdCancha",
                table: "AtributoCanchas",
                column: "IdCancha");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosComplejo_IdComplejo",
                table: "ServiciosComplejo",
                column: "IdComplejo");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosComplejo_IdServicio",
                table: "ServiciosComplejo",
                column: "IdServicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtributoCanchas");

            migrationBuilder.DropTable(
                name: "ServiciosComplejo");

            migrationBuilder.AddColumn<Guid>(
                name: "IdComplejo",
                table: "Servicios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdCancha",
                table: "Atributos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdComplejo",
                table: "Servicios",
                column: "IdComplejo");

            migrationBuilder.CreateIndex(
                name: "IX_Atributos_IdCancha",
                table: "Atributos",
                column: "IdCancha");

            migrationBuilder.AddForeignKey(
                name: "FK_Atributos_Canchas_IdCancha",
                table: "Atributos",
                column: "IdCancha",
                principalTable: "Canchas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Complejos_IdComplejo",
                table: "Servicios",
                column: "IdComplejo",
                principalTable: "Complejos",
                principalColumn: "Id");
        }
    }
}
