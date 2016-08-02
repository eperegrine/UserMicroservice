using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroservice.API.Migrations
{
    public partial class AddedGeneratedProps2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Permissions_PermissionsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PermissionsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PermissionsId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PermissionId",
                table: "Users",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Permissions_PermissionId",
                table: "Users",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Permissions_PermissionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PermissionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "PermissionsId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PermissionsId",
                table: "Users",
                column: "PermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Permissions_PermissionsId",
                table: "Users",
                column: "PermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
