using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.Migrations
{
    public partial class Change_TableName_PasswordSites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordsSites_AspNetUsers_UserId",
                table: "PasswordsSites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PasswordsSites",
                table: "PasswordsSites");

            migrationBuilder.RenameTable(
                name: "PasswordsSites",
                newName: "PasswordSites");

            migrationBuilder.RenameIndex(
                name: "IX_PasswordsSites_UserId",
                table: "PasswordSites",
                newName: "IX_PasswordSites_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PasswordSites",
                table: "PasswordSites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordSites_AspNetUsers_UserId",
                table: "PasswordSites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordSites_AspNetUsers_UserId",
                table: "PasswordSites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PasswordSites",
                table: "PasswordSites");

            migrationBuilder.RenameTable(
                name: "PasswordSites",
                newName: "PasswordsSites");

            migrationBuilder.RenameIndex(
                name: "IX_PasswordSites_UserId",
                table: "PasswordsSites",
                newName: "IX_PasswordsSites_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PasswordsSites",
                table: "PasswordsSites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordsSites_AspNetUsers_UserId",
                table: "PasswordsSites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
