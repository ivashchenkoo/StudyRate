using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyRate.Migrations
{
    public partial class _facultyColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortForm",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShortForm",
                value: "ФТІТ");

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShortForm",
                value: "ФЕП");

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShortForm",
                value: "ФТБ");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDElBkwzT01Tgx3sRPq9gmX+djARvIXwl9QoV2ZDsJMTghILHbrsxeUaUs/2NICzJQ==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHJKiMSQ8nx5kwEwC5PQYaUXDQ1s9Dit3cKfoQuSd+QpGRbPYYFFA/xKmhhCPraSAg==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPiD13D8+V98OCNgIxSi3G1LhXZvJHj9ZB9ngiAak83gc9WjuRB5cAv9i2T14vGFyw==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBjkdrlwEiGKYJjZWgJ1PADVgMV1PdX3SqgRKgX90ytXEdqF2Bqa2+TSrH4tt20Ytw==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPJe94o8bLb+QJSueXL42GuTZLbJsS2nnXl2FCVwLhrUqiOLGZIhj+XRAHbNVDqP1g==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEN+ESgdTpiIWcmNSpAklVV5Vnvop4Y8tpkAuNuz3l0xvslWDAa6ZPYMdruKHo5/tHA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortForm",
                table: "Faculties");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPB738/RwtDoWss5LdZkWZ4XcaIUE0X7N9enF21AVV3WIunor/IAz2vD7hhxrhd6SA==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPwQ3xeXTo01kUEmcgQ5DCauHRuYAPwmOn9aHuiCpPUwRL7oPxOvJk3wolLMUZzf0w==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPOkJKGaDUG1//DWyaWZ70LLT7QmXmDwldx1MTXb3axK5yfLdgHVqoK3UTKtXEtQWA==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEC0MMrruu/BVP+0evdiwDldusQrEq8hF+2NG/dJCmHPEDN/QpDsNeuoLqsuuBk20ZA==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELx+nxhz/08pqeKg8ry8Q997p5CRqz1z3ecYSWVN99E55MGD6zdZJYz9lcztjzt73g==");

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECj3q8yMSuc4Xxgf5DA9+agOgsm8EjBzFUiLgnz2EDbCDgJaDvPiyLTUaUKbQggkvA==");
        }
    }
}
