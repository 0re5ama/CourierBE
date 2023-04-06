using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class moved_checkpoint_to_security : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"),
                columns: new[] { "MUrl", "ParentId" },
                values: new object[] { "/Security/Checkpoint", new Guid("78ce1776-2cee-43d8-892a-b9eabefea327") });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("b70f5399-8929-4493-bcc3-75c38721ed21"),
                column: "ApplicationId",
                value: new Guid("541f2c3a-c67e-4b70-b58d-188486b7e04a"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"),
                columns: new[] { "MUrl", "ParentId" },
                values: new object[] { "/ProductTracking/Checkpoint", new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f") });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("b70f5399-8929-4493-bcc3-75c38721ed21"),
                column: "ApplicationId",
                value: new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"));
        }
    }
}
