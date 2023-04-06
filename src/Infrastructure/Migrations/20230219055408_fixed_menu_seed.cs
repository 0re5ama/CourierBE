using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class fixed_menu_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("0365f4a8-1574-42bd-a331-4e160c6c40ed"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("05a9b8bd-e08b-4493-b7fd-f47602b63ca8"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("2cf6f49d-69a6-47d7-a473-58d941538bab"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"),
                columns: new[] { "Icon", "MenuText" },
                values: new object[] { null, "Consignmnet" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("400f7539-aa3e-459c-9159-154759fd5e12"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("412d4976-15b3-451c-9ddd-1fda0ae45fb1"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("49b12a5a-6e12-48d2-bd86-8e83382ca4e7"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("807041f5-a442-422c-94c7-0065e46c483c"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8a314e94-1102-4b65-a2a9-9552133cf10f"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8b52e051-0d8b-49ff-a515-53b2ad9a9975"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("a779afac-05fa-4334-9b6b-2ede4a925cd4"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"),
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("b9019358-a9f8-4f29-b6f3-e9ca572bbab7"),
                columns: new[] { "Icon", "OrderNo" },
                values: new object[] { null, 4 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"),
                column: "Icon",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("0365f4a8-1574-42bd-a331-4e160c6c40ed"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("05a9b8bd-e08b-4493-b7fd-f47602b63ca8"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("2cf6f49d-69a6-47d7-a473-58d941538bab"),
                column: "Icon",
                value: "smile");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"),
                columns: new[] { "Icon", "MenuText" },
                values: new object[] { "form", "ConsignmnetEntry" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("400f7539-aa3e-459c-9159-154759fd5e12"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("412d4976-15b3-451c-9ddd-1fda0ae45fb1"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("49b12a5a-6e12-48d2-bd86-8e83382ca4e7"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("807041f5-a442-422c-94c7-0065e46c483c"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8a314e94-1102-4b65-a2a9-9552133cf10f"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8b52e051-0d8b-49ff-a515-53b2ad9a9975"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("a779afac-05fa-4334-9b6b-2ede4a925cd4"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"),
                column: "Icon",
                value: "form");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("b9019358-a9f8-4f29-b6f3-e9ca572bbab7"),
                columns: new[] { "Icon", "OrderNo" },
                values: new object[] { "form", 6 });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"),
                column: "Icon",
                value: "form");
        }
    }
}
