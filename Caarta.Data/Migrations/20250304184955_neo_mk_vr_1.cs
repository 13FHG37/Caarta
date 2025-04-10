using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caarta.Data.Migrations
{
    /// <inheritdoc />
    public partial class neo_mk_vr_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Type",
                table: "Cards",
                type: "tinyint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cards");
        }
    }
}
