using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Happy5SocialMedia.Activity.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserSender = table.Column<Guid>(nullable: false),
                    UserReciever = table.Column<Guid>(nullable: false),
                    Status = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequest_ActivityStatus",
                        column: x => x.Status,
                        principalTable: "ActivityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendRelationship",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FriendRequestId = table.Column<Guid>(nullable: false),
                    Status = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRelationship_FriendRequest",
                        column: x => x.FriendRequestId,
                        principalTable: "FriendRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendRelationship_ActivityStatus",
                        column: x => x.Status,
                        principalTable: "ActivityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ActivityStatus",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("47334304-9f19-467f-9646-429d29943a81"), "Accepted", "Accepted" },
                    { new Guid("1a07418e-40b1-491b-bbc3-2273874f8b77"), "Request", "Request" },
                    { new Guid("02a2815b-53bf-4c7e-a15e-9319389fa7cb"), "Pending", "Pending" },
                    { new Guid("62dbf46e-f666-4158-a041-db4610afb3f5"), "Declined", "Declined" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRelationship_FriendRequestId",
                table: "FriendRelationship",
                column: "FriendRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRelationship_Status",
                table: "FriendRelationship",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_Status",
                table: "FriendRequest",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRelationship");

            migrationBuilder.DropTable(
                name: "FriendRequest");

            migrationBuilder.DropTable(
                name: "ActivityStatus");
        }
    }
}
