using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge03.Migrations
{
    public partial class Startingv12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Cards_Card_BId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Players_Player_BId",
                table: "Batalhas");

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

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Card_AId1",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player_AId1",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Card_AId",
                table: "Batalhas",
                column: "Card_AId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Card_AId1",
                table: "Batalhas",
                column: "Card_AId1");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Player_AId",
                table: "Batalhas",
                column: "Player_AId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_Player_AId1",
                table: "Batalhas",
                column: "Player_AId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Cards_Card_AId1",
                table: "Batalhas",
                column: "Card_AId1",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Players_Player_AId1",
                table: "Batalhas",
                column: "Player_AId1",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Cards_Card_AId1",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Players_Player_AId1",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Card_AId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Card_AId1",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_Player_AId",
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

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Cards_Card_BId",
                table: "Batalhas",
                column: "Card_BId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Players_Player_BId",
                table: "Batalhas",
                column: "Player_BId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
