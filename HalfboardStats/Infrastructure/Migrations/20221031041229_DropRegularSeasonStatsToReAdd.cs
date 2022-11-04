using Microsoft.EntityFrameworkCore.Migrations;

namespace HalfboardStats.Migrations
{
    public partial class DropRegularSeasonStatsToReAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegularSeasonStats");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
