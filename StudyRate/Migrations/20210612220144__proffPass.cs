using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyRate.Migrations
{
    public partial class _proffPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "25y8VeXDr6");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "7M479dMKyt");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "fUGbd4F557");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "tFBvcS4548");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "V9cR5vZ79z");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "ZH8L6znt45");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGuIbhM5uzJjx10sXjwaVTCoHUdCRmxf2GfJIifm2Me+iGi6zhK2OG70MQFjxKaXUA==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHUezkerYgT7cwm/0ACJzfqbFl9EY5Ih0ZY1vioRF3VxhsXvSejLz3llTvgdcjLzeA==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEB2tEZyIJVVg3Zr8rPSxie3ZljM7JFnln4zL+oUYZSH+4GL+bxm2z62SVmI9lGLeHQ==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEA9zPDtvT9vlgMA0XLPVETT0RHtyxmtgqLIM4VsWfOMm7AG+suOgYPhHljayF0DuaQ==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIU5LfZA+qRjdmhhW11TJKn+WJbJgYOXNd9cAGqh9eqhSWbOsNWpP0FyIzdSP1nizQ==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFafp9x+ZEVx+IkaWyBC3p1tBJp02sCuT7R2lI1zbDREkpJ4oRkIwIc0y3h0CGU49g==");
        }
    }
}
