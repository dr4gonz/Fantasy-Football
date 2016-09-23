using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFootball.Migrations
{
    public partial class UpdateMigrations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Leagues_LeagueId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LeagueId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LeagueId",
                table: "AspNetUsers",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Leagues_LeagueId",
                table: "AspNetUsers",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
