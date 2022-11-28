using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Personagens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPersonagem",
                table: "Personagens",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Personagens",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Armas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Jogador"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, null, null, null, null, new byte[] { 204, 230, 246, 192, 74, 43, 24, 236, 151, 244, 118, 3, 14, 122, 25, 108, 215, 113, 169, 68, 3, 86, 254, 15, 63, 215, 168, 152, 95, 237, 120, 186, 229, 215, 46, 190, 117, 54, 35, 205, 106, 181, 126, 197, 239, 187, 107, 253, 252, 7, 55, 254, 70, 4, 161, 237, 162, 240, 215, 133, 3, 42, 190, 178 }, new byte[] { 12, 97, 134, 51, 167, 228, 130, 255, 159, 155, 229, 89, 106, 65, 120, 118, 165, 56, 104, 163, 115, 173, 135, 33, 59, 49, 208, 223, 7, 24, 167, 196, 48, 75, 1, 220, 235, 79, 197, 116, 229, 118, 38, 164, 64, 161, 177, 243, 76, 129, 96, 38, 164, 193, 231, 19, 213, 74, 24, 151, 156, 108, 163, 173, 126, 183, 252, 32, 150, 254, 246, 243, 82, 235, 179, 186, 174, 15, 250, 170, 19, 216, 194, 163, 214, 174, 43, 91, 217, 126, 34, 216, 197, 22, 176, 171, 162, 244, 225, 176, 143, 202, 1, 110, 132, 21, 185, 79, 143, 59, 153, 85, 187, 103, 41, 222, 34, 63, 104, 193, 80, 14, 188, 205, 60, 11, 220, 134 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "FotoPersonagem",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Personagens");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Personagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Armas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
