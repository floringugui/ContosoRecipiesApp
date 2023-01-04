using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContosoRecipiesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeRightRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 4, 9, 28, 17, 623, DateTimeKind.Local).AddTicks(7058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Title", "Updated" },
                values: new object[,]
                {
                    { 1, "Breakfast1 Description", "Breakfast1", new DateTime(2023, 1, 4, 9, 28, 17, 623, DateTimeKind.Local).AddTicks(8066) },
                    { 2, "Dinner1 Description", "Dinner1", new DateTime(2023, 1, 3, 9, 28, 17, 623, DateTimeKind.Local).AddTicks(8152) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 4, 9, 28, 17, 623, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
