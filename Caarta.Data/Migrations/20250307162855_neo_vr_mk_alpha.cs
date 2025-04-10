using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caarta.Data.Migrations
{
    /// <inheritdoc />
    public partial class neo_vr_mk_alpha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardlistId",
                table: "Decks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cardlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    TimeOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cardlists_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cardlists_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Decks_CardlistId",
                table: "Decks",
                column: "CardlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Cardlists_CreatorId",
                table: "Cardlists",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cardlists_LanguageId",
                table: "Cardlists",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_Cardlists_CardlistId",
                table: "Decks",
                column: "CardlistId",
                principalTable: "Cardlists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Cardlists_CardlistId",
                table: "Decks");

            migrationBuilder.DropTable(
                name: "Cardlists");

            migrationBuilder.DropIndex(
                name: "IX_Decks_CardlistId",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "CardlistId",
                table: "Decks");
        }
    }
}
