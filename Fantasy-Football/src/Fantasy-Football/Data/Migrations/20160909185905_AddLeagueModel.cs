using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fantasy_Football.Data.Migrations
{
    public partial class AddLeagueModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Team_LeagueId",
                table: "Team",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_League_LeagueId",
                table: "Team",
                column: "LeagueId",
                principalTable: "League",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_League_LeagueId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_LeagueId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "League");
        }
    }
}
