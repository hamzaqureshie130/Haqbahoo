using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructionLayer.Haqbahoo.Migrations
{
    /// <inheritdoc />
    public partial class UpdatecoloumNameInWorkShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverImage",
                table: "Workshop",
                newName: "CoverImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverImageUrl",
                table: "Workshop",
                newName: "CoverImage");
        }
    }
}
