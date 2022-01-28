using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectComplete.Migrations
{
    public partial class CommentValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_CollectionId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_CollectionId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Collections");

            migrationBuilder.AddColumn<string>(
                name: "value",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserId",
                table: "Collections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_UserId",
                table: "Collections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_UserId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_UserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "value",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CollectionId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CollectionId",
                table: "Collections",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_CollectionId",
                table: "Collections",
                column: "CollectionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
