using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFootball.Migrations
{
    public partial class AddPlayerIDtoPlayerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Opinion",
                table: "NflNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "NflNews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Opinion",
                table: "NflNews");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "NflNews");
        }
    }
}
