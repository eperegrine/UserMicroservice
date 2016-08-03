using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroservice.API.Migrations
{
    public partial class AddedAlternateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Email_Username",
                table: "Users",
                columns: new[] { "Email", "Username" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Email_Username",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);
        }
    }
}
