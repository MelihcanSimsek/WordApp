using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ForeignWord = table.Column<string>(type: "text", nullable: false),
                    TranslatedWord = table.Column<string>(type: "text", nullable: false),
                    LastCheckedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    KnownType = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Synonms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WordId = table.Column<Guid>(type: "uuid", nullable: false),
                    ForeignWord = table.Column<string>(type: "text", nullable: false),
                    TranslatedWord = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Synonms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Synonms_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Synonms_WordId",
                table: "Synonms",
                column: "WordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Synonms");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
