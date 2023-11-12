using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge03.Migrations
{
    public partial class Startin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Baralhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baralhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baralhos_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assinatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaralhoId = table.Column<int>(type: "int", nullable: true),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Elemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    SP = table.Column<int>(type: "int", nullable: false),
                    Forca = table.Column<int>(type: "int", nullable: false),
                    Defesa = table.Column<int>(type: "int", nullable: false),
                    Agilidade = table.Column<int>(type: "int", nullable: false),
                    Inteligencia = table.Column<int>(type: "int", nullable: false),
                    BaralhoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Baralhos_BaralhoId",
                        column: x => x.BaralhoId,
                        principalTable: "Baralhos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Baralhos_BaralhoId1",
                        column: x => x.BaralhoId1,
                        principalTable: "Baralhos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Batalhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player_AId = table.Column<int>(type: "int", nullable: false),
                    Card_AId = table.Column<int>(type: "int", nullable: false),
                    Escolha_A = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player_BId = table.Column<int>(type: "int", nullable: false),
                    Card_BId = table.Column<int>(type: "int", nullable: false),
                    Escolha_B = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VencedorId = table.Column<int>(type: "int", nullable: true),
                    LogBatalha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batalhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batalhas_Cards_Card_AId",
                        column: x => x.Card_AId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Batalhas_Cards_Card_BId",
                        column: x => x.Card_BId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Batalhas_Players_Player_AId",
                        column: x => x.Player_AId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Batalhas_Players_Player_BId",
                        column: x => x.Player_BId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Batalhas_Players_VencedorId",
                        column: x => x.VencedorId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baralhos_PlayerId",
                table: "Baralhos",
                column: "PlayerId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_VencedorId",
                table: "Batalhas",
                column: "VencedorId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batalhas");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Baralhos");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
