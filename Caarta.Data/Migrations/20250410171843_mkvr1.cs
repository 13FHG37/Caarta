using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caarta.Data.Migrations
{
    /// <inheritdoc />
    public partial class mkvr1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckInCardlist_Cardlists_CardlistId",
                table: "DeckInCardlist");

            migrationBuilder.DropForeignKey(
                name: "FK_DeckInCardlist_Decks_DeckId",
                table: "DeckInCardlist");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckInCardlist_Cardlists_CardlistId",
                table: "DeckInCardlist",
                column: "CardlistId",
                principalTable: "Cardlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeckInCardlist_Decks_DeckId",
                table: "DeckInCardlist",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckInCardlist_Cardlists_CardlistId",
                table: "DeckInCardlist");

            migrationBuilder.DropForeignKey(
                name: "FK_DeckInCardlist_Decks_DeckId",
                table: "DeckInCardlist");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckInCardlist_Cardlists_CardlistId",
                table: "DeckInCardlist",
                column: "CardlistId",
                principalTable: "Cardlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeckInCardlist_Decks_DeckId",
                table: "DeckInCardlist",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
