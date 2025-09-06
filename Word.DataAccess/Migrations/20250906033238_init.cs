using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnWord.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    enWriting = table.Column<string>(type: "text", nullable: false),
                    transcription = table.Column<string>(type: "text", nullable: false),
                    ruWriting = table.Column<string>(type: "text", nullable: false),
                    freqRepeat = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
