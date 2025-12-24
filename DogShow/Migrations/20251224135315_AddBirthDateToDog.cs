using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogShow.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthDateToDog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionJudge_Judges_JudgeId",
                table: "CompetitionJudge");

            migrationBuilder.AddColumn<string>(
                name: "CompetitionClass",
                table: "FormForDogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "FormForDogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Dogs",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Size",
                table: "Dogs",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Dogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "Dogs",
                type: "date",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_FormForDogs_CompetitionId",
                table: "FormForDogs",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionJudge_Judges_JudgeId",
                table: "CompetitionJudge",
                column: "JudgeId",
                principalTable: "Judges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormForDogs_Competitions_CompetitionId",
                table: "FormForDogs",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionJudge_Judges_JudgeId",
                table: "CompetitionJudge");

            migrationBuilder.DropForeignKey(
                name: "FK_FormForDogs_Competitions_CompetitionId",
                table: "FormForDogs");

            migrationBuilder.DropIndex(
                name: "IX_FormForDogs_CompetitionId",
                table: "FormForDogs");

            migrationBuilder.DropColumn(
                name: "CompetitionClass",
                table: "FormForDogs");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "FormForDogs");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Dogs");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Dogs",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Size",
                table: "Dogs",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionJudge_Judges_JudgeId",
                table: "CompetitionJudge",
                column: "JudgeId",
                principalTable: "Judges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
