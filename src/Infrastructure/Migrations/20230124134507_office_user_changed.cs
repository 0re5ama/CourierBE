using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class office_user_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1887fc0-caf5-4b3d-9930-525c8d296e05"));

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: new Guid("187cda14-9844-42e7-99ba-b8d4f0d59c3a"),
                columns: new[] { "EntryDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: new Guid("187cda14-9844-42e7-99ba-b8d4f0d59c3a"),
                columns: new[] { "EntryDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 1, 19, 15, 54, 49, 408, DateTimeKind.Local).AddTicks(2377), new DateTime(2023, 1, 19, 15, 54, 49, 408, DateTimeKind.Local).AddTicks(8744) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AuthorizationDate", "AuthorizationNo", "AuthorizedBy", "CheckpointId", "ConcurrencyStamp", "Contact", "Email", "EmailConfirmed", "EmployeeId", "EntryBy", "EntryDate", "HasPasswordChanged", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "OfficeId", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { new Guid("d1887fc0-caf5-4b3d-9930-525c8d296e05"), 0, null, null, null, null, "df299433-0a3f-4154-bb1e-e9ccecbc09e8", null, "SuperAdmin", false, new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 1, 19, 10, 9, 49, 407, DateTimeKind.Utc).AddTicks(8373), false, false, null, "info@superadmin.com", null, null, new Guid("187cda14-9844-42e7-99ba-b8d4f0d59c3a"), null, null, null, null, false, null, 0, false, null, "SuperAdmin@gmail.com" });
        }
    }
}
