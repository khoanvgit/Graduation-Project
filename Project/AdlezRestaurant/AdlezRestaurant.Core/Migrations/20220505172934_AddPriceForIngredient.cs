using Microsoft.EntityFrameworkCore.Migrations;

namespace AdlezRestaurant.Core.Migrations
{
    public partial class AddPriceForIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "552b614f-a1bf-4d52-8f91-7217ac3b6d9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73158f61-6dd8-40ce-9e33-627b0ea32d04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "969376fb-ceee-4823-8871-83638daab7f8");

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedPrice",
                table: "Ingredient",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9f47601-81c7-4ae3-9f93-ed0cb888a808", "00b48591-ca0a-47c4-ab1d-8704b92e6db0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34c92fc6-1a9f-4ad8-b8ff-0444c7228ffe", "f3ebafad-c1a5-4266-b238-dbfa6d0c2365", "Waiter/waitress", "WAITER/WAITRESS" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4dc98e8-4144-4700-b6d8-597b0d1308f7", "00163ba1-a977-4b7f-a387-4e3de126f700", "Chef", "CHEF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34c92fc6-1a9f-4ad8-b8ff-0444c7228ffe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9f47601-81c7-4ae3-9f93-ed0cb888a808");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4dc98e8-4144-4700-b6d8-597b0d1308f7");

            migrationBuilder.DropColumn(
                name: "EstimatedPrice",
                table: "Ingredient");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73158f61-6dd8-40ce-9e33-627b0ea32d04", "deafb618-4ef0-462e-a940-1e6eac1da2c1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "552b614f-a1bf-4d52-8f91-7217ac3b6d9b", "fd2db22b-0d99-4ae8-81bc-f8872e96eae4", "Waiter/waitress", "WAITER/WAITRESS" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "969376fb-ceee-4823-8871-83638daab7f8", "0ee613f1-a217-40a4-bd40-d520dd68c608", "Chef", "CHEF" });
        }
    }
}
