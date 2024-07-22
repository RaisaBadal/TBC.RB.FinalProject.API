using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RB.TBC.FinalProject.Domain.Migrations
{
    /// <inheritdoc />
    public partial class MigrateNow3454 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feadbacks",
                columns: table => new
                {
                    FeadbackId = table.Column<string>(type: "TEXT", nullable: false),
                    User_Feadback = table.Column<string>(type: "TEXT", nullable: false),
                    FeadbackDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name_Of_User = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Rating_By_User = table.Column<int>(type: "INTEGER", nullable: false),
                    Feadback_Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feadbacks", x => x.FeadbackId);
                    table.ForeignKey(
                        name: "FK_Feadbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feadbacks_UserId",
                table: "Feadbacks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feadbacks");
        }
    }
}
