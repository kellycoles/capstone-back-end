using Microsoft.EntityFrameworkCore.Migrations;

namespace MowPro.Migrations
{
    public partial class isDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Service",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "08e58616-83bd-41f5-b492-be2439f5bd0c", "AQAAAAEAACcQAAAAEMU9ykYaIruqco9g57eOFimOD/bXCNpi8x4dpA18qAfIniyWWL+xQs419xPnjO4CjA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Service");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63daf8b5-b955-4a8b-9849-b2a9d7dee27d", "AQAAAAEAACcQAAAAEK0D65giC+HydD64pf4dpxxOFgSlcsgltY8xTNguZ+l7ILRvnsrWZdXQxgpdHrNDpA==" });
        }
    }
}
