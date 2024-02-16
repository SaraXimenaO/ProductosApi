using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Api.Migrations
{
    /// <inheritdoc />
    public partial class Generateidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_ProductId",
                table: "Product",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_ProductId",
                table: "Product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");
        }
    }
}
