using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Happy5SocialMedia.User.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Parent = table.Column<Guid>(nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUser", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountUser");
        }
    }
}
