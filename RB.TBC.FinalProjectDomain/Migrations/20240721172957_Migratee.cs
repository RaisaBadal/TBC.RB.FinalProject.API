using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RB.TBC.FinalProject.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Migratee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageLinks",
                columns: table => new
                {
                    ImageId = table.Column<string>(type: "TEXT", nullable: false),
                    VolumeInfo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageLinks", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "VolumeInfo",
                columns: table => new
                {
                    VolumeInfoId = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    authors = table.Column<string>(type: "TEXT", nullable: false),
                    imageLinksId = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolumeInfo", x => x.VolumeInfoId);
                    table.ForeignKey(
                        name: "FK_VolumeInfo_ImageLinks_imageLinksId",
                        column: x => x.imageLinksId,
                        principalTable: "ImageLinks",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    VolumeInfoId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_VolumeInfo_VolumeInfoId",
                        column: x => x.VolumeInfoId,
                        principalTable: "VolumeInfo",
                        principalColumn: "VolumeInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_VolumeInfoId",
                table: "Books",
                column: "VolumeInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VolumeInfo_imageLinksId",
                table: "VolumeInfo",
                column: "imageLinksId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "VolumeInfo");

            migrationBuilder.DropTable(
                name: "ImageLinks");
        }
    }
}
