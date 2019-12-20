using Microsoft.EntityFrameworkCore.Migrations;

namespace MowPro.Migrations
{
    public partial class serviceDeleteConstraint : Migration
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
                values: new object[] { "6ab0b2fb-fb7f-4777-ab61-0a60de364131", "AQAAAAEAACcQAAAAEEO0ghM350oH2vcQyjVRodXkDPgXogpmBZkNQJt+PnS9p5QJEi1sDKhYk11Kj+Obxw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Service_ServiceId",
                table: "Job",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);
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
                values: new object[] { "c7707ba4-4a80-4d10-858e-51a160863410", "AQAAAAEAACcQAAAAENjCbMDc/sOi/M7fpeUI4hD1j3SMAhPMKF4mp48jGCpdzn0RzTtwgQ0fcx2uMw7Nsw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Service_ServiceId",
                table: "Job",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
