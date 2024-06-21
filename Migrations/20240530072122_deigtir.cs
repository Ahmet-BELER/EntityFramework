using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityApp.Migrations
{
    /// <inheritdoc />
    public partial class deigtir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OgrenciId",
                table: "KursKayıtları",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KursKayıtları_KursId",
                table: "KursKayıtları",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursKayıtları_OgrenciId",
                table: "KursKayıtları",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayıtları_Kurslar_KursId",
                table: "KursKayıtları",
                column: "KursId",
                principalTable: "Kurslar",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayıtları_Ogrenciler_OgrenciId",
                table: "KursKayıtları",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursKayıtları_Kurslar_KursId",
                table: "KursKayıtları");

            migrationBuilder.DropForeignKey(
                name: "FK_KursKayıtları_Ogrenciler_OgrenciId",
                table: "KursKayıtları");

            migrationBuilder.DropIndex(
                name: "IX_KursKayıtları_KursId",
                table: "KursKayıtları");

            migrationBuilder.DropIndex(
                name: "IX_KursKayıtları_OgrenciId",
                table: "KursKayıtları");

            migrationBuilder.AlterColumn<string>(
                name: "OgrenciId",
                table: "KursKayıtları",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
