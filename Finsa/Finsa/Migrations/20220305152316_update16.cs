using Microsoft.EntityFrameworkCore.Migrations;

namespace Finsa.Migrations
{
    public partial class update16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentSelfId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CommentSelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentSelves", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentSelfId",
                table: "Comments",
                column: "CommentSelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CommentSelves_CommentSelfId",
                table: "Comments",
                column: "CommentSelfId",
                principalTable: "CommentSelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CommentSelves_CommentSelfId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "CommentSelves");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentSelfId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentSelfId",
                table: "Comments");
        }
    }
}
