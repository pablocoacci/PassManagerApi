using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.Migrations
{
    public partial class FK_PasswordsSites_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PasswordsSites",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PasswordsSites_UserId",
                table: "PasswordsSites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordsSites_AspNetUsers_UserId",
                table: "PasswordsSites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordsSites_AspNetUsers_UserId",
                table: "PasswordsSites");

            migrationBuilder.DropIndex(
                name: "IX_PasswordsSites_UserId",
                table: "PasswordsSites");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PasswordsSites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
