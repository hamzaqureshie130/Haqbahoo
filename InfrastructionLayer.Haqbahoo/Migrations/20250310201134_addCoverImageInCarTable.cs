using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructionLayer.Haqbahoo.Migrations
{
    /// <inheritdoc />
    public partial class addCoverImageInCarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Cars");
        }
    }
}
