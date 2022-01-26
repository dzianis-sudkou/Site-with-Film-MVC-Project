using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectComplete.Migrations
{
    public partial class ColUse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
