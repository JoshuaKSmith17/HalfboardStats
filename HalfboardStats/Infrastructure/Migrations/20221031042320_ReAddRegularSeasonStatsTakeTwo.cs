using Microsoft.EntityFrameworkCore.Migrations;

namespace HalfboardStats.Migrations
{
    public partial class ReAddRegularSeasonStatsTakeTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegularSeasonStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Shots = table.Column<int>(type: "int", nullable: false),
                    Games = table.Column<int>(type: "int", nullable: false),
                    Hits = table.Column<int>(type: "int", nullable: false),
                    PowerPlayGoals = table.Column<int>(type: "int", nullable: false),
                    PowerPlayPoints = table.Column<int>(type: "int", nullable: false),
                    PowerPlayTimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvenStrengthTimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PenaltyMinutes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceOffPct = table.Column<double>(type: "float", nullable: false),
                    ShotPct = table.Column<double>(type: "float", nullable: false),
                    GameWinningGoals = table.Column<int>(type: "int", nullable: false),
                    OverTimeGoals = table.Column<int>(type: "int", nullable: false),
                    ShortHandedGoals = table.Column<int>(type: "int", nullable: false),
                    ShortHandedPoints = table.Column<int>(type: "int", nullable: false),
                    ShortHandedTimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShotsBlocked = table.Column<int>(type: "int", nullable: false),
                    PlusMinus = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Shifts = table.Column<int>(type: "int", nullable: false),
                    TimeOnIcePerGame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvenTimeOnIcePerGame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortHandedTimeOnIcePerGame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerPlayTimeOnIcePerGame = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularSeasonStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegularSeasonStats_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegularSeasonStats_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegularSeasonStats_PlayerId",
                table: "RegularSeasonStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularSeasonStats_TeamId",
                table: "RegularSeasonStats",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegularSeasonStats");
        }
    }
}
