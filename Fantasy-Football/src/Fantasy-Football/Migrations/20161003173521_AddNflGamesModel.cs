using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FantasyFootball.Migrations
{
    public partial class AddNflGamesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NflGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AwayScore = table.Column<string>(nullable: true),
                    AwayScoreOvertime = table.Column<string>(nullable: true),
                    AwayScoreQuarter1 = table.Column<string>(nullable: true),
                    AwayScoreQuarter2 = table.Column<string>(nullable: true),
                    AwayScoreQuarter3 = table.Column<string>(nullable: true),
                    AwayScoreQuarter4 = table.Column<string>(nullable: true),
                    AwayTeam = table.Column<string>(nullable: true),
                    HomeScore = table.Column<string>(nullable: true),
                    HomeScoreOvertime = table.Column<string>(nullable: true),
                    HomeScoreQuarter1 = table.Column<string>(nullable: true),
                    HomeScoreQuarter2 = table.Column<string>(nullable: true),
                    HomeScoreQuarter3 = table.Column<string>(nullable: true),
                    HomeScoreQuarter4 = table.Column<string>(nullable: true),
                    HomeTeam = table.Column<string>(nullable: true),
                    StadiumName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NflGames", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NflGames");
        }
    }
}
