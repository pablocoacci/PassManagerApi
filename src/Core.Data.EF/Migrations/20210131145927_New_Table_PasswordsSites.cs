using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.EF.Migrations
{
    public partial class New_Table_PasswordsSites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordsSites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    NameSite = table.Column<string>(maxLength: 100, nullable: false),
                    URLSite = table.Column<string>(maxLength: 100, nullable: false),
                    DescriptionSite = table.Column<string>(maxLength: 700, nullable: true),
                    UserNameSite = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    SecretAnswer = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordsSites", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordsSites");
        }
    }
}
