using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Buy_Plus.Migrations
{
    /// <inheritdoc />
    public partial class unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_UserID",
                table: "Permissions");

            migrationBuilder.AddColumn<bool>(
                name: "DeleteCategory",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteFatora",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteProduct",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserID",
                table: "Permissions",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissions_UserID",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DeleteCategory",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DeleteFatora",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DeleteProduct",
                table: "Permissions");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserID",
                table: "Permissions",
                column: "UserID");
        }
    }
}
