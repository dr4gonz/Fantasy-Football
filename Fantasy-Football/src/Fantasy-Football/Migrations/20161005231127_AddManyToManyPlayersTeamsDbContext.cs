using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFootball.Migrations
{
    public partial class AddManyToManyPlayersTeamsDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersTeams_Players_PlayerId",
                table: "PlayersTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersTeams_Teams_TeamId",
                table: "PlayersTeams");

            migrationBuilder.DropIndex(
                name: "IX_PlayersTeams_PlayerId",
                table: "PlayersTeams");

            migrationBuilder.DropIndex(
                name: "IX_PlayersTeams_TeamId",
                table: "PlayersTeams");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "PlayersTeams");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "PlayersTeams");

            migrationBuilder.AddColumn<int>(
                name: "PlayersTeamsId",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayersTeamsId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlayersTeamsId",
                table: "Teams",
                column: "PlayersTeamsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayersTeamsId",
                table: "Players",
                column: "PlayersTeamsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayersTeams_PlayersTeamsId",
                table: "Players",
                column: "PlayersTeamsId",
                principalTable: "PlayersTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_PlayersTeams_PlayersTeamsId",
                table: "Teams",
                column: "PlayersTeamsId",
                principalTable: "PlayersTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayersTeams_PlayersTeamsId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_PlayersTeams_PlayersTeamsId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_PlayersTeamsId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayersTeamsId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayersTeamsId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PlayersTeamsId",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "PlayersTeams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "PlayersTeams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayersTeams_PlayerId",
                table: "PlayersTeams",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersTeams_TeamId",
                table: "PlayersTeams",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersTeams_Players_PlayerId",
                table: "PlayersTeams",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersTeams_Teams_TeamId",
                table: "PlayersTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
