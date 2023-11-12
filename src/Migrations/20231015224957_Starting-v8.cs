using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge03.Migrations
{
    public partial class Startingv8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baralhos_Players_PlayerId",
                table: "Baralhos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Baralhos_BaralhoId",
                table: "Cards");

            migrationBuilder.AddForeignKey(
                name: "FK_Baralhos_Players_PlayerId",
                table: "Baralhos",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Baralhos_BaralhoId",
                table: "Cards",
                column: "BaralhoId",
                principalTable: "Baralhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baralhos_Players_PlayerId",
                table: "Baralhos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Baralhos_BaralhoId",
                table: "Cards");

            migrationBuilder.AddForeignKey(
                name: "FK_Baralhos_Players_PlayerId",
                table: "Baralhos",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Baralhos_BaralhoId",
                table: "Cards",
                column: "BaralhoId",
                principalTable: "Baralhos",
                principalColumn: "Id");
        }
    }
}
