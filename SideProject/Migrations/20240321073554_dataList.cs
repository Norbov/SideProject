using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SideProject.Migrations
{
    /// <inheritdoc />
    public partial class dataList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageId",
                table: "uploads");

            migrationBuilder.AddColumn<string>(
                name: "imageIds",
                table: "uploads",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "videIds",
                table: "uploads",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fileFormat = table.Column<int>(type: "INTEGER", nullable: false),
                    video = table.Column<byte[]>(type: "BLOB", nullable: false),
                    user = table.Column<string>(type: "TEXT", nullable: false),
                    applicationUseruserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videos_accounts_applicationUseruserName",
                        column: x => x.applicationUseruserName,
                        principalTable: "accounts",
                        principalColumn: "userName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_videos_applicationUseruserName",
                table: "videos",
                column: "applicationUseruserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "videos");

            migrationBuilder.DropColumn(
                name: "imageIds",
                table: "uploads");

            migrationBuilder.DropColumn(
                name: "videIds",
                table: "uploads");

            migrationBuilder.AddColumn<int>(
                name: "imageId",
                table: "uploads",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
