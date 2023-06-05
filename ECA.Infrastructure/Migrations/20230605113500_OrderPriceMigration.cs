using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderPriceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderPrice",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "FirstName", "IsDeleted", "LastName" },
                values: new object[] { 3, "Koliste", "Cazin", "Faruk", false, "Sackin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "OrderPrice",
                table: "Orders");
        }
    }
}
