using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOfSweets_DataAccess.Migrations
{
    public partial class AddProductToDbTryAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoruName",
                table: "Category",
                newName: "CategoryName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "CategoruName");
        }
    }
}
