using Microsoft.EntityFrameworkCore.Migrations;

namespace Finsa.Migrations
{
    public partial class update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percent",
                table: "TeamToSkills");

            migrationBuilder.AddColumn<byte>(
                name: "Percent",
                table: "Skills",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percent",
                table: "Skills");

            migrationBuilder.AddColumn<byte>(
                name: "Percent",
                table: "TeamToSkills",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
