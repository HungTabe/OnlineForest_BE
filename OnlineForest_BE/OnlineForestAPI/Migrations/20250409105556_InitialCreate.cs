using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineForestAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LandCategories",
                columns: table => new
                {
                    LandCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxSlots = table.Column<int>(type: "int", nullable: false),
                    LandPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandCategories", x => x.LandCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TreeCategories",
                columns: table => new
                {
                    TreeCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TreePrice = table.Column<int>(type: "int", nullable: false),
                    GrowthTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeCategories", x => x.TreeCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalTokenEarn = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    LandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LandSpecificName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LandCategoryId = table.Column<int>(type: "int", nullable: false),
                    LastPlanted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.LandId);
                    table.ForeignKey(
                        name: "FK_Lands_LandCategories_LandCategoryId",
                        column: x => x.LandCategoryId,
                        principalTable: "LandCategories",
                        principalColumn: "LandCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lands_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    TreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TreeCategoryId = table.Column<int>(type: "int", nullable: false),
                    LandId = table.Column<int>(type: "int", nullable: true),
                    IsHarvest = table.Column<bool>(type: "bit", nullable: false),
                    TokenEarnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.TreeId);
                    table.ForeignKey(
                        name: "FK_Trees_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "LandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trees_TreeCategories_TreeCategoryId",
                        column: x => x.TreeCategoryId,
                        principalTable: "TreeCategories",
                        principalColumn: "TreeCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TokenEarns",
                columns: table => new
                {
                    TokenEarnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Tokens = table.Column<int>(type: "int", nullable: false),
                    EarnedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TreeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenEarns", x => x.TokenEarnId);
                    table.ForeignKey(
                        name: "FK_TokenEarns_Trees_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Trees",
                        principalColumn: "TreeId");
                    table.ForeignKey(
                        name: "FK_TokenEarns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lands_LandCategoryId",
                table: "Lands",
                column: "LandCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_UserId",
                table: "Lands",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenEarns_TreeId",
                table: "TokenEarns",
                column: "TreeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TokenEarns_UserId",
                table: "TokenEarns",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_LandId",
                table: "Trees",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_TreeCategoryId",
                table: "Trees",
                column: "TreeCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TokenEarns");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "TreeCategories");

            migrationBuilder.DropTable(
                name: "LandCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
