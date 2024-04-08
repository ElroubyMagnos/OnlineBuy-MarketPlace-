using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Buy_Plus.Migrations
{
    /// <inheritdoc />
    public partial class CatString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryString",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryString",
                table: "Products",
                column: "CategoryString");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryString",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryString",
                table: "Products",
                column: "CategoryString",
                unique: true);
        }
    }
}
