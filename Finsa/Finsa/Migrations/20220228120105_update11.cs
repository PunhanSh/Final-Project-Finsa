using Microsoft.EntityFrameworkCore.Migrations;

namespace Finsa.Migrations
{
    public partial class update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamToSkills_Skills_SkillId",
                table: "TeamToSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamToSkills_Teams_TeamId",
                table: "TeamToSkills");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "TeamToSkills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "TeamToSkills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamToSkills_Skills_SkillId",
                table: "TeamToSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamToSkills_Teams_TeamId",
                table: "TeamToSkills",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamToSkills_Skills_SkillId",
                table: "TeamToSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamToSkills_Teams_TeamId",
                table: "TeamToSkills");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "TeamToSkills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "TeamToSkills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamToSkills_Skills_SkillId",
                table: "TeamToSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamToSkills_Teams_TeamId",
                table: "TeamToSkills",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
