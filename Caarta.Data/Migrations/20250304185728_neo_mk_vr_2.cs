using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caarta.Data.Migrations
{
    /// <inheritdoc />
    public partial class neo_mk_vr_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Cards",
                newName: "CardType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardType",
                table: "Cards",
                newName: "Type");
        }
    }
}
