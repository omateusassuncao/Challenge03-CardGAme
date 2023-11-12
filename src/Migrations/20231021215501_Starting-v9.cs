using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge03.Migrations
{
    public partial class Startingv9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaralhoId",
                table: "Players",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaralhoId",
                table: "Players");
        }
    }
}
