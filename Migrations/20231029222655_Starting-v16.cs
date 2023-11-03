using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge03.Migrations
{
    public partial class Startingv16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Cards_Card_AId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Cards_Card_AId1",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Players_Player_AId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Players_Player_AId1",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Card_AId1",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Player_AId1",
                table: "Batalhas");

            migrationBuilder.DropColumn(
                name: "Card_AId1",
                table: "Batalhas");

            migrationBuilder.DropColumn(
                name: "Player_AId1",
                table: "Batalhas");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Card_BId",
                table: "Batalhas",
                column: "Card_BId",
                unique: true,
                filter: "[Card_BId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Player_BId",
                table: "Batalhas",
                column: "Player_BId",
                unique: true,
                filter: "[Player_BId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Cards_Card_AId",
                table: "Batalhas",
                column: "Card_AId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Cards_Card_BId",
                table: "Batalhas",
                column: "Card_BId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Players_Player_AId",
                table: "Batalhas",
                column: "Player_AId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Players_Player_BId",
                table: "Batalhas",
                column: "Player_BId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Cards_Card_AId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Cards_Card_BId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Players_Player_AId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Players_Player_BId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Card_BId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Player_BId",
                table: "Batalhas");

            migrationBuilder.AddColumn<int>(
                name: "Card_AId1",
                table: "Batalhas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Player_AId1",
                table: "Batalhas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Card_AId1",
                table: "Batalhas",
                column: "Card_AId1");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Player_AId1",
                table: "Batalhas",
                column: "Player_AId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Cards_Card_AId",
                table: "Batalhas",
                column: "Card_AId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Cards_Card_AId1",
                table: "Batalhas",
                column: "Card_AId1",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Players_Player_AId",
                table: "Batalhas",
                column: "Player_AId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Players_Player_AId1",
                table: "Batalhas",
                column: "Player_AId1",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
