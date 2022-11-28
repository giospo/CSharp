using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoUmParaUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Armas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemHabilidades",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemHabilidades", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 142, 186, 100, 29, 140, 177, 178, 38, 16, 68, 28, 24, 216, 48, 76, 83, 208, 99, 36, 203, 85, 99, 214, 129, 138, 168, 19, 48, 254, 72, 19, 201, 46, 100, 32, 118, 11, 60, 240, 186, 33, 175, 21, 252, 79, 131, 222, 132, 140, 218, 172, 163, 5, 3, 185, 89, 44, 41, 125, 213, 108, 43, 245, 214 }, new byte[] { 185, 3, 77, 63, 171, 71, 23, 106, 246, 143, 83, 118, 173, 223, 86, 47, 142, 203, 240, 231, 100, 114, 55, 160, 106, 131, 7, 64, 97, 11, 175, 202, 127, 170, 178, 46, 114, 176, 247, 169, 224, 248, 102, 22, 130, 64, 92, 25, 70, 148, 252, 209, 208, 91, 12, 135, 236, 193, 144, 72, 1, 64, 167, 198, 92, 174, 65, 146, 191, 111, 81, 183, 182, 199, 255, 174, 136, 247, 90, 156, 0, 161, 247, 141, 233, 152, 86, 170, 200, 3, 113, 241, 100, 184, 218, 3, 80, 142, 148, 187, 112, 148, 157, 153, 245, 237, 57, 145, 43, 195, 158, 102, 234, 146, 132, 164, 188, 64, 118, 201, 79, 3, 207, 112, 84, 197, 112, 166 } });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidades",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemHabilidades_HabilidadeId",
                table: "PersonagemHabilidades",
                column: "HabilidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas");

            migrationBuilder.DropTable(
                name: "PersonagemHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Armas");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 204, 230, 246, 192, 74, 43, 24, 236, 151, 244, 118, 3, 14, 122, 25, 108, 215, 113, 169, 68, 3, 86, 254, 15, 63, 215, 168, 152, 95, 237, 120, 186, 229, 215, 46, 190, 117, 54, 35, 205, 106, 181, 126, 197, 239, 187, 107, 253, 252, 7, 55, 254, 70, 4, 161, 237, 162, 240, 215, 133, 3, 42, 190, 178 }, new byte[] { 12, 97, 134, 51, 167, 228, 130, 255, 159, 155, 229, 89, 106, 65, 120, 118, 165, 56, 104, 163, 115, 173, 135, 33, 59, 49, 208, 223, 7, 24, 167, 196, 48, 75, 1, 220, 235, 79, 197, 116, 229, 118, 38, 164, 64, 161, 177, 243, 76, 129, 96, 38, 164, 193, 231, 19, 213, 74, 24, 151, 156, 108, 163, 173, 126, 183, 252, 32, 150, 254, 246, 243, 82, 235, 179, 186, 174, 15, 250, 170, 19, 216, 194, 163, 214, 174, 43, 91, 217, 126, 34, 216, 197, 22, 176, 171, 162, 244, 225, 176, 143, 202, 1, 110, 132, 21, 185, 79, 143, 59, 153, 85, 187, 103, 41, 222, 34, 63, 104, 193, 80, 14, 188, 205, 60, 11, 220, 134 } });
        }
    }
}
