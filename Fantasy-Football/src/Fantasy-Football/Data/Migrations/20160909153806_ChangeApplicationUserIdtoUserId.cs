using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy_Football.Data.Migrations
{
    public partial class ChangeApplicationUserIdtoUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_AspNetUsers_ApplicationUserId1",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_ApplicationUserId1",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Team");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_ApplicationUserId",
                table: "Team",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_AspNetUsers_ApplicationUserId",
                table: "Team",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_AspNetUsers_ApplicationUserId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_ApplicationUserId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Team");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Team",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Team",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Team_ApplicationUserId1",
                table: "Team",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_AspNetUsers_ApplicationUserId1",
                table: "Team",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
