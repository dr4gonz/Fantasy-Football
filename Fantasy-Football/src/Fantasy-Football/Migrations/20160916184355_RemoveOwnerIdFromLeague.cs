using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyFootball.Migrations
{
    public partial class RemoveOwnerIdFromLeague : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_AspNetUsers_OwnerId1",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_OwnerId1",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Leagues");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Leagues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_OwnerId",
                table: "Leagues",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_AspNetUsers_OwnerId",
                table: "Leagues",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_AspNetUsers_OwnerId",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_OwnerId",
                table: "Leagues");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Leagues",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Leagues",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_OwnerId1",
                table: "Leagues",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_AspNetUsers_OwnerId1",
                table: "Leagues",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
