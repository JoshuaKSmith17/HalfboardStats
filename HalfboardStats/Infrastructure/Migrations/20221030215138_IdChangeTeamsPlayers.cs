using Microsoft.EntityFrameworkCore.Migrations;

namespace HalfboardStats.Migrations
{
    public partial class IdChangeTeamsPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Team",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Player",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Team",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Player",
                newName: "PlayerId");
        }
    }
}
