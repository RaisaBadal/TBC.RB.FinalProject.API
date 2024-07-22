using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RB.TBC.FinalProject.Domain.Migrations
{
    /// <inheritdoc />
    public partial class MigrateNow34548 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_VolumeInfo_VolumeInfoId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "VolumeInfo");

            migrationBuilder.DropTable(
                name: "ImageLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_VolumeInfoId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "VolumeInfoId",
                table: "Books",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "imageLink");

            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "authors",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookId");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteId = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    BookId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_Favorites_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_BookId",
                table: "Favorites",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "authors",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Books",
                newName: "VolumeInfoId");

            migrationBuilder.RenameColumn(
                name: "imageLink",
                table: "Books",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

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
                    imageLinksId = table.Column<string>(type: "TEXT", nullable: false),
                    authors = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Books_VolumeInfo_VolumeInfoId",
                table: "Books",
                column: "VolumeInfoId",
                principalTable: "VolumeInfo",
                principalColumn: "VolumeInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
