using Microsoft.EntityFrameworkCore.Migrations;

namespace HalfboardStats.Migrations
{
    public partial class FixedPlayerSeasonRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSeasons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerSeasons",
                columns: table => new
                {
                    PlayerSeasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    BlockedShots = table.Column<int>(type: "int", nullable: false),
                    EvenStrengthTimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvenTimeOnIcePerGame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceOffPct = table.Column<int>(type: "int", nullable: false),
                    GameWinningGoals = table.Column<int>(type: "int", nullable: false),
                    Games = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Hits = table.Column<int>(type: "int", nullable: false),
                    OverTimeGoals = table.Column<int>(type: "int", nullable: false),
                    PenaltyMinutes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pim = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    PlusMinus = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    PowerPlayGoals = table.Column<int>(type: "int", nullable: false),
                    PowerPlayPoints = table.Column<int>(type: "int", nullable: false),
                    PowerPlayTimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerPlayTimeOnIcePerGame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeasonSplit = table.Column<int>(type: "int", nullable: false),
                    Shifts = table.Column<int>(type: "int", nullable: false),
                    ShortHandedGoals = table.Column<int>(type: "int", nullable: false),
                    ShortHandedPoints = table.Column<int>(type: "int", nullable: false),
                    ShortHandedTimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortHandedTimeOnIcePerGame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShotPct = table.Column<int>(type: "int", nullable: false),
                    Shots = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    TimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOnIcePerGame = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSeasons", x => x.PlayerSeasonId);
                    table.ForeignKey(
                        name: "FK_PlayerSeasons_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasons_PlayerId",
                table: "PlayerSeasons",
                column: "PlayerId");
        }
    }
}
