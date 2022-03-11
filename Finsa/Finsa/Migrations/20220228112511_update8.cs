using Microsoft.EntityFrameworkCore.Migrations;

namespace Finsa.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamToSkills");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TeamId",
                table: "Skills",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Teams_TeamId",
                table: "Skills",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Teams_TeamId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_TeamId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "TeamToSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamToSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamToSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamToSkills_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamToSkills_SkillId",
                table: "TeamToSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamToSkills_TeamId",
                table: "TeamToSkills",
                column: "TeamId");
        }
    }
}
