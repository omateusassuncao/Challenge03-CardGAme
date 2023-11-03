using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge03.Migrations
{
    public partial class Startingv15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Cards_Card_AId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Players_Player_AId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Players_VencedorId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Card_AId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Player_AId",
                table: "Batalhas");

            migrationBuilder.AlterColumn<int>(
                name: "Player_BId",
                table: "Batalhas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Player_AId",
                table: "Batalhas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Card_BId",
                table: "Batalhas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Card_AId",
                table: "Batalhas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Card_AId",
                table: "Batalhas",
                column: "Card_AId",
                unique: true,
                filter: "[Card_AId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Player_AId",
                table: "Batalhas",
                column: "Player_AId",
                unique: true,
                filter: "[Player_AId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Cards_Card_AId",
                table: "Batalhas",
                column: "Card_AId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Cards_VencedorId",
                table: "Batalhas",
                column: "VencedorId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Players_Player_AId",
                table: "Batalhas",
                column: "Player_AId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Cards_Card_AId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Cards_VencedorId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Players_Player_AId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Card_AId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Player_AId",
                table: "Batalhas");

            migrationBuilder.AlterColumn<int>(
                name: "Player_BId",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Player_AId",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Card_BId",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Card_AId",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Card_AId",
                table: "Batalhas",
                column: "Card_AId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Player_AId",
                table: "Batalhas",
                column: "Player_AId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Cards_Card_AId",
                table: "Batalhas",
                column: "Card_AId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Players_Player_AId",
                table: "Batalhas",
                column: "Player_AId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Players_VencedorId",
                table: "Batalhas",
                column: "VencedorId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
