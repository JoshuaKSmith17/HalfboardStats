using Microsoft.EntityFrameworkCore.Migrations;

namespace HalfboardStats.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    FranchiseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstYearOfPlay = table.Column<int>(type: "int", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialSiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAge = table.Column<int>(type: "int", nullable: false),
                    BirthCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthStateProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAlternateCaptain = table.Column<bool>(type: "bit", nullable: false),
                    IsCaptain = table.Column<bool>(type: "bit", nullable: false),
                    IsRookie = table.Column<bool>(type: "bit", nullable: false),
                    ShootsCatches = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RosterStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayingPosition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSeason",
                columns: table => new
                {
                    TeamSeasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeason", x => x.TeamSeasonId);
                    table.ForeignKey(
                        name: "FK_TeamSeason_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSeason",
                columns: table => new
                {
                    PlayerSeasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeasonSplit = table.Column<int>(type: "int", nullable: false),
                    TimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Pim = table.Column<int>(type: "int", nullable: false),
                    Shots = table.Column<int>(type: "int", nullable: false),
                    Games = table.Column<int>(type: "int", nullable: false),
                    Hits = table.Column<int>(type: "int", nullable: false),
                    PowerPlayGoals = table.Column<int>(type: "int", nullable: false),
                    PowerPlayPoints = table.Column<int>(type: "int", nullable: false),
                    PowerPlayTimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvenStrengthTimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PenaltyMinutes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceOffPct = table.Column<int>(type: "int", nullable: false),
                    ShotPct = table.Column<int>(type: "int", nullable: false),
                    GameWinningGoals = table.Column<int>(type: "int", nullable: false),
                    OverTimeGoals = table.Column<int>(type: "int", nullable: false),
                    ShortHandedGoals = table.Column<int>(type: "int", nullable: false),
                    ShortHandedPoints = table.Column<int>(type: "int", nullable: false),
                    ShortHandedTimeOnIce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlockedShots = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PlayerSeason", x => x.PlayerSeasonId);
                    table.ForeignKey(
                        name: "FK_PlayerSeason_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeason_PlayerId",
                table: "PlayerSeason",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeason_TeamId",
                table: "TeamSeason",
                column: "TeamId");
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSeason");

            migrationBuilder.DropTable(
                name: "TeamSeason");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
