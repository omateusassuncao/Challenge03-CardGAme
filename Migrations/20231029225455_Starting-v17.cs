using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge03.Migrations
{
    public partial class Startingv17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Card_AId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Card_BId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Player_AId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Player_BId",
                table: "Batalhas");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Card_AId",
                table: "Batalhas",
                column: "Card_AId");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Card_BId",
                table: "Batalhas",
                column: "Card_BId");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Player_AId",
                table: "Batalhas",
                column: "Player_AId");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Player_BId",
                table: "Batalhas",
                column: "Player_BId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Card_AId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Card_BId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Player_AId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Player_BId",
                table: "Batalhas");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Card_AId",
                table: "Batalhas",
                column: "Card_AId",
                unique: true,
                filter: "[Card_AId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Card_BId",
                table: "Batalhas",
                column: "Card_BId",
                unique: true,
                filter: "[Card_BId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Player_AId",
                table: "Batalhas",
                column: "Player_AId",
                unique: true,
                filter: "[Player_AId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Player_BId",
                table: "Batalhas",
                column: "Player_BId",
                unique: true,
                filter: "[Player_BId] IS NOT NULL");
        }
    }
}
