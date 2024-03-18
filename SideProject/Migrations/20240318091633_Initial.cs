using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SideProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    userName = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    roles = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fileFormat = table.Column<int>(type: "INTEGER", nullable: false),
                    image = table.Column<byte[]>(type: "BLOB", nullable: false),
                    user = table.Column<string>(type: "TEXT", nullable: false),
                    applicationUseruserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_images_accounts_applicationUseruserName",
                        column: x => x.applicationUseruserName,
                        principalTable: "accounts",
                        principalColumn: "userName");
                });

            migrationBuilder.CreateTable(
                name: "uploads",
                columns: table => new
                {
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    aplicationUseruserName = table.Column<string>(type: "TEXT", nullable: true),
                    imageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_uploads_accounts_aplicationUseruserName",
                        column: x => x.aplicationUseruserName,
                        principalTable: "accounts",
                        principalColumn: "userName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_images_applicationUseruserName",
                table: "images",
                column: "applicationUseruserName");

            migrationBuilder.CreateIndex(
                name: "IX_uploads_aplicationUseruserName",
                table: "uploads",
                column: "aplicationUseruserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "uploads");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
