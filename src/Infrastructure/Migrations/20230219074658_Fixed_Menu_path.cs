using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class Fixed_Menu_path : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"),
                column: "MUrl",
                value: "/ProductTracking");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"),
                column: "MUrl",
                value: "/Security");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"),
                column: "MUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"),
                column: "MUrl",
                value: null);
        }
    }
}
