using Microsoft.EntityFrameworkCore.Migrations;

namespace AudiobookLibrary.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudiobookFiles",
                columns: table => new
                {
                    AudiobookFileId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Album = table.Column<string>(nullable: true),
                    Disc = table.Column<int>(nullable: true),
                    Track = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Filename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudiobookFiles", x => x.AudiobookFileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudiobookFiles");
        }
    }
}
