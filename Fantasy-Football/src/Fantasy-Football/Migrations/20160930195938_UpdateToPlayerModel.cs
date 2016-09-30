using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFootball.Migrations
{
    public partial class UpdateToPlayerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "FantasyPoints",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Fumbles",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "FumblesLost",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PassingAttempts",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PassingCompletions",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PassingInterceptions",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PassingRating",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PassingTouchdowns",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PassingYards",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PassintCompletionPercentage",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Played",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ReceivingTargets",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ReceivingTouchdowns",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ReceivingYards",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Receptions",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RecevingYardsPerReception",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RushingAttempts",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RushingTouchdowns",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RushingYards",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RushingYardsPerAttempt",
                table: "Players",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Started",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Players",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FantasyPoints",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Fumbles",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FumblesLost",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PassingAttempts",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PassingCompletions",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PassingInterceptions",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PassingRating",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PassingTouchdowns",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PassingYards",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PassintCompletionPercentage",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Played",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ReceivingTargets",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ReceivingTouchdowns",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ReceivingYards",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Receptions",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RecevingYardsPerReception",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RushingAttempts",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RushingTouchdowns",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RushingYards",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RushingYardsPerAttempt",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Started",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "Players");
        }
    }
}
