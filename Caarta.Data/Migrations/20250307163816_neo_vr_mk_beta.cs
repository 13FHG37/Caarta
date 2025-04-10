using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caarta.Data.Migrations
{
    /// <inheritdoc />
    public partial class neo_vr_mk_beta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Cardlists_CardlistId",
                table: "Decks");

            migrationBuilder.DropIndex(
                name: "IX_Decks_CardlistId",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "CardlistId",
                table: "Decks");

            migrationBuilder.CreateTable(
                name: "DeckInCardlist",
                columns: table => new
                {
                    DeckId = table.Column<int>(type: "int", nullable: false),
                    CardlistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckInCardlist", x => new { x.DeckId, x.CardlistId });
                    table.ForeignKey(
                        name: "FK_DeckInCardlist_Cardlists_CardlistId",
                        column: x => x.CardlistId,
                        principalTable: "Cardlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeckInCardlist_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckInCardlist_CardlistId",
                table: "DeckInCardlist",
                column: "CardlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeckInCardlist");

            migrationBuilder.AddColumn<int>(
                name: "CardlistId",
                table: "Decks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decks_CardlistId",
                table: "Decks",
                column: "CardlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_Cardlists_CardlistId",
                table: "Decks",
                column: "CardlistId",
                principalTable: "Cardlists",
                principalColumn: "Id");
        }
    }
}
