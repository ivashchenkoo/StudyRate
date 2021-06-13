using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyRate.Migrations
{
    public partial class _admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auth_key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password_hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password_reset_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Auth_key", "Email", "Password_hash", "Password_reset_token", "Role", "Status", "Username" },
                values: new object[] { 1, null, null, "admin12345", null, null, null, "Oleksandr_Iv" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
