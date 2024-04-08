using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Buy_Plus.Migrations
{
    /// <inheritdoc />
    public partial class branch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPanel");

            migrationBuilder.AddColumn<string>(
                name: "BuyerAddress",
                table: "Fwater",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BuyerPhone",
                table: "Fwater",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Delivery",
                table: "Fwater",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReady",
                table: "Fwater",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxWeight = table.Column<int>(type: "int", nullable: false),
                    OurAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OurPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropColumn(
                name: "BuyerAddress",
                table: "Fwater");

            migrationBuilder.DropColumn(
                name: "BuyerPhone",
                table: "Fwater");

            migrationBuilder.DropColumn(
                name: "Delivery",
                table: "Fwater");

            migrationBuilder.DropColumn(
                name: "IsReady",
                table: "Fwater");

            migrationBuilder.CreateTable(
                name: "CPanel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxWeight = table.Column<int>(type: "int", nullable: false),
                    OurAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OurPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPanel", x => x.ID);
                });
        }
    }
}
