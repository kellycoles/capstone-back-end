using Microsoft.EntityFrameworkCore.Migrations;

namespace MowPro.Migrations
{
    public partial class removeConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Service_ServiceId",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63daf8b5-b955-4a8b-9849-b2a9d7dee27d", "AQAAAAEAACcQAAAAEK0D65giC+HydD64pf4dpxxOFgSlcsgltY8xTNguZ+l7ILRvnsrWZdXQxgpdHrNDpA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Service_ServiceId",
                table: "Job",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Service_ServiceId",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ab0b2fb-fb7f-4777-ab61-0a60de364131", "AQAAAAEAACcQAAAAEEO0ghM350oH2vcQyjVRodXkDPgXogpmBZkNQJt+PnS9p5QJEi1sDKhYk11Kj+Obxw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Service_ServiceId",
                table: "Job",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
