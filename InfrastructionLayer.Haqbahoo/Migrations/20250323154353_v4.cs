using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructionLayer.Haqbahoo.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                table: "Products",
                newName: "SalePrice");

            migrationBuilder.RenameColumn(
                name: "PurchasingPrice",
                table: "Products",
                newName: "PurchasePrice");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Inventories",
                newName: "QuantityOut");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityIn",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "QuantityIn",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "SalePrice",
                table: "Products",
                newName: "SellingPrice");

            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "Products",
                newName: "PurchasingPrice");

            migrationBuilder.RenameColumn(
                name: "QuantityOut",
                table: "Inventories",
                newName: "Quantity");
        }
    }
}
