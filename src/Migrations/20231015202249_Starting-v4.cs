using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge03.Migrations
{
    public partial class Startingv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Baralhos_BaralhoId1",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_BaralhoId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_BaralhoId1",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BaralhoId1",
                table: "Cards");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BaralhoId",
                table: "Cards",
                column: "BaralhoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cards_BaralhoId",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "BaralhoId1",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BaralhoId",
                table: "Cards",
                column: "BaralhoId",
                unique: true,
                filter: "[BaralhoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BaralhoId1",
                table: "Cards",
                column: "BaralhoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Baralhos_BaralhoId1",
                table: "Cards",
                column: "BaralhoId1",
                principalTable: "Baralhos",
                principalColumn: "Id");
        }
    }
}
