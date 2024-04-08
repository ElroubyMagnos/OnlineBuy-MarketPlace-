using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Buy_Plus.Migrations
{
    /// <inheritdoc />
    public partial class perm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteCategory",
                table: "Permissions",
                newName: "DeleteUser");

            migrationBuilder.AddColumn<bool>(
                name: "BillPanel",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillPanel",
                table: "Permissions");

            migrationBuilder.RenameColumn(
                name: "DeleteUser",
                table: "Permissions",
                newName: "DeleteCategory");
        }
    }
}
