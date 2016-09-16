using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFootball.Migrations
{
    public partial class RemoveUserId1FromTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_UserId1",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_UserId1",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Teams");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UserId",
                table: "Teams",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_UserId",
                table: "Teams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_UserId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_UserId",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Teams",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UserId1",
                table: "Teams",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_UserId1",
                table: "Teams",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
