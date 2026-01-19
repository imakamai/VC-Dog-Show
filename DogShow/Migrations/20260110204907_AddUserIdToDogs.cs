using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogShow.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToDogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Clear existing data to avoid FK conflicts
            migrationBuilder.Sql("DELETE FROM FormForDogs");
            migrationBuilder.Sql("DELETE FROM Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_FormForDogs_Users_UserId",
                table: "FormForDogs");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Dogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_UserId",
                table: "Dogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Users_UserId",
                table: "Dogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormForDogs_Users_UserId",
                table: "FormForDogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Users_UserId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_FormForDogs_Users_UserId",
                table: "FormForDogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_UserId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dogs");

            migrationBuilder.AddForeignKey(
                name: "FK_FormForDogs_Users_UserId",
                table: "FormForDogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
