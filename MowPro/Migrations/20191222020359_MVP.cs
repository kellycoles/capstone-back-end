using Microsoft.EntityFrameworkCore.Migrations;

namespace MowPro.Migrations
{
    public partial class MVP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8a3ecd6-c031-4b38-959b-6b3fb065e1fd", "AQAAAAEAACcQAAAAEL5Ol7uxHKpX0CyQxZhxnM8hA+2MU2eoW2pUk4L1jlhEx5zVJbx3hCFELW3UHjZwoQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "08e58616-83bd-41f5-b492-be2439f5bd0c", "AQAAAAEAACcQAAAAEMU9ykYaIruqco9g57eOFimOD/bXCNpi8x4dpA18qAfIniyWWL+xQs419xPnjO4CjA==" });
        }
    }
}
