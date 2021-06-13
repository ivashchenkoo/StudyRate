using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyRate.Migrations
{
    public partial class _posTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Professors");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionID",
                table: "Professors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Dean",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortForm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name", "ShortForm" },
                values: new object[,]
                {
                    { 1, "Викладач", "Викл." },
                    { 2, "Старший викладач", "Ст. викл." },
                    { 3, "Доцент", "Доц." },
                    { 4, "Професор", "Проф." }
                });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PositionID" },
                values: new object[] { "AQAAAAEAACcQAAAAEBRBn6BOf4CzdudPzYUEuSpdBmg3yDENORtnnsAO/K84EUwruLUWZha9dFdS5X0uLg==", 3 });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PositionID" },
                values: new object[] { "AQAAAAEAACcQAAAAEJnryqsSoNbrYGaRcV0ofV92blFQpzouwaOGF41qV4TpgHkrNRIok+aAEWxCiWcSSw==", 2 });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PositionID" },
                values: new object[] { "AQAAAAEAACcQAAAAEF+pCNFvw31CdPatRFQ7khajH8LH0ELmL/U8OvAU7dCfUyuTO0PFOawdEmoP8gHSTw==", 1 });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PositionID" },
                values: new object[] { "AQAAAAEAACcQAAAAEPtEaKPV+LH1QRtiynMZGVvFBwFOmUD+Cbm+Eqo4CoO8sq16nNCpPUCIukgUZBX4cw==", 4 });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PositionID" },
                values: new object[] { "AQAAAAEAACcQAAAAEAjjfzUh/hT+3nb1KRMSUGhIrSViEOu+amPo03BxN075GAbgBvC+CNy0xJ71plVVsA==", 3 });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PositionID" },
                values: new object[] { "AQAAAAEAACcQAAAAEHoZeIMc7OhGSxOLgilrrjap1xvh/0hO8VY8t60gwdmH1kIfLx32KwZ5qQkg0MTF9w==", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Professors_PositionID",
                table: "Professors",
                column: "PositionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Positions_PositionID",
                table: "Professors",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Positions_PositionID",
                table: "Professors");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Professors_PositionID",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PositionID",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "Dean",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "HeadName",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Position" },
                values: new object[] { "AQAAAAEAACcQAAAAEDElBkwzT01Tgx3sRPq9gmX+djARvIXwl9QoV2ZDsJMTghILHbrsxeUaUs/2NICzJQ==", "Доцент" });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "Position" },
                values: new object[] { "AQAAAAEAACcQAAAAEHJKiMSQ8nx5kwEwC5PQYaUXDQ1s9Dit3cKfoQuSd+QpGRbPYYFFA/xKmhhCPraSAg==", "Старший викладач" });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "Position" },
                values: new object[] { "AQAAAAEAACcQAAAAEPiD13D8+V98OCNgIxSi3G1LhXZvJHj9ZB9ngiAak83gc9WjuRB5cAv9i2T14vGFyw==", "Старший викладач" });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "Position" },
                values: new object[] { "AQAAAAEAACcQAAAAEBjkdrlwEiGKYJjZWgJ1PADVgMV1PdX3SqgRKgX90ytXEdqF2Bqa2+TSrH4tt20Ytw==", "Професор" });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "Position" },
                values: new object[] { "AQAAAAEAACcQAAAAEPJe94o8bLb+QJSueXL42GuTZLbJsS2nnXl2FCVwLhrUqiOLGZIhj+XRAHbNVDqP1g==", "Доцент" });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "Position" },
                values: new object[] { "AQAAAAEAACcQAAAAEN+ESgdTpiIWcmNSpAklVV5Vnvop4Y8tpkAuNuz3l0xvslWDAa6ZPYMdruKHo5/tHA==", "Старший викладач" });
        }
    }
}
