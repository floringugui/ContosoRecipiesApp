using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContosoRecipiesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDirectionsAndIngredientsRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 4, 9, 53, 59, 970, DateTimeKind.Local).AddTicks(851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 4, 9, 28, 17, 623, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Directions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Directions",
                columns: new[] { "Id", "Description", "RecipeId", "Step" },
                values: new object[,]
                {
                    { 1, "Direction1 Description", 1, "Direction1" },
                    { 2, "Direction2 Description", 1, "Direction2" },
                    { 3, "Direction3 Description", 1, "Direction3" },
                    { 4, "Direction4 Description", 2, "Direction4" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "Name", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Ingredient1 Description", "Ingredient1", 1 },
                    { 2, "Ingredient2 Description", "Ingredient2", 1 },
                    { 3, "Ingredient3 Description", "Ingredient3", 2 },
                    { 4, "Ingredient4 Description", "Ingredient4", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Updated",
                value: new DateTime(2023, 1, 4, 9, 53, 59, 970, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Updated",
                value: new DateTime(2023, 1, 3, 9, 53, 59, 970, DateTimeKind.Local).AddTicks(2184));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 4, 9, 28, 17, 623, DateTimeKind.Local).AddTicks(7058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 4, 9, 53, 59, 970, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Directions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Updated",
                value: new DateTime(2023, 1, 4, 9, 28, 17, 623, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Updated",
                value: new DateTime(2023, 1, 3, 9, 28, 17, 623, DateTimeKind.Local).AddTicks(8152));
        }
    }
}
