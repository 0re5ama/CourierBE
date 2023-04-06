using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class added_parent_menu_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("0365f4a8-1574-42bd-a331-4e160c6c40ed"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("05a9b8bd-e08b-4493-b7fd-f47602b63ca8"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("2cf6f49d-69a6-47d7-a473-58d941538bab"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"),
                columns: new[] { "Active", "ParentId", "ToolTip" },
                values: new object[] { true, null, "Consignment" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("400f7539-aa3e-459c-9159-154759fd5e12"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("49b12a5a-6e12-48d2-bd86-8e83382ca4e7"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"),
                columns: new[] { "Active", "ToolTip" },
                values: new object[] { true, "Product Tracking" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8a314e94-1102-4b65-a2a9-9552133cf10f"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8b52e051-0d8b-49ff-a515-53b2ad9a9975"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("a779afac-05fa-4334-9b6b-2ede4a925cd4"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("b9019358-a9f8-4f29-b6f3-e9ca572bbab7"),
                columns: new[] { "Active", "ParentId" },
                values: new object[] { true, null });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"),
                columns: new[] { "Active", "ToolTip" },
                values: new object[] { true, "Container List" });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("2776fcc6-9152-44dc-9eb3-09feb06f1e03"),
                column: "Description",
                value: "Admin Dashboard");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("d6ab380b-8a6d-4def-86b7-d28cbe3e734c"),
                column: "Description",
                value: "Container List");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("e0818357-af77-4a05-9879-3aeb0749ae0f"),
                column: "Description",
                value: "Item Groups");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ed0ddce0-b06b-4915-aa79-bde61ac1a22f"),
                column: "Description",
                value: "Search Consignment");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentId",
                table: "Menu",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Menu_ParentId",
                table: "Menu",
                column: "ParentId",
                principalTable: "Menu",
                principalColumn: "Id");

            migrationBuilder.Sql($@"
ALTER PROCEDURE [cfn_get_user_menu]
	@p_user_id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT distinct me.""Id"" AS ""Id"",
        a.""Id"" AS ""ApplicationId"",
        me.""MenuText"" AS ""MenuText"",
        me.""MUrl"" AS ""MUrl"",
        me.""ParentId"" AS ""ParentId"",
        me.""Icon"" AS ""Icon""
    FROM ""UserRoles"" ur
    JOIN ""Roles"" r
        ON r.""Id"" = ur.""RoleId""
    JOIN ""RoleModuleFunctions"" rmf
        ON rmf.""RoleId"" = ur.""RoleId""
            OR r.""Name"" = 'Admin'
    JOIN ""Functions"" f
        ON f.""Id"" = rmf.""ModuleFunctionId""
        and f.""FunctionId"" = 1
    JOIN ""Modules"" mo
        ON mo.""Id"" = f.""ModuleId""
    JOIN ""Applications"" a
        ON a.""Id"" = mo.""ApplicationId""
    JOIN ""Menu"" me
        ON me.""Id"" = Mo.""MenuId""
    WHERE ur.""UserId"" = @p_user_id
    and me.""Active"" = 1;
END;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Menu_ParentId",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_ParentId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Menu");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"),
                columns: new[] { "ParentId", "ToolTip" },
                values: new object[] { new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "ConsignmentEntry" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"),
                column: "ToolTip",
                value: "productTracking");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("b9019358-a9f8-4f29-b6f3-e9ca572bbab7"),
                column: "ParentId",
                value: new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"),
                column: "ToolTip",
                value: "ContainerList");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("2776fcc6-9152-44dc-9eb3-09feb06f1e03"),
                column: "Description",
                value: "AdminDashboard");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("d6ab380b-8a6d-4def-86b7-d28cbe3e734c"),
                column: "Description",
                value: "ContainerList");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("e0818357-af77-4a05-9879-3aeb0749ae0f"),
                column: "Description",
                value: "ItemGroups");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ed0ddce0-b06b-4915-aa79-bde61ac1a22f"),
                column: "Description",
                value: "SearchConsignment");

            migrationBuilder.Sql($@"
ALTER PROCEDURE [cfn_get_user_menu]
	@p_user_id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT distinct me.""Id"" AS ""Id"",
        a.""Id"" AS ""ApplicationId"",
        me.""MenuText"" AS ""MenuText"",
        me.""MUrl"" AS ""MUrl"",
        me.""ParentId"" AS ""ParentId"",
        me.""Icon"" AS ""Icon""
    FROM ""UserRoles"" ur
    JOIN ""Roles"" r
        ON r.""Id"" = ur.""RoleId""
    JOIN ""RoleModuleFunctions"" rmf
        ON rmf.""RoleId"" = ur.""RoleId""
            OR r.""Name"" = 'Admin'
    JOIN ""Functions"" f
        ON f.""Id"" = rmf.""ModuleFunctionId""
        and f.""FunctionId"" = 1
    JOIN ""Modules"" mo
        ON mo.""Id"" = f.""ModuleId""
    JOIN ""Applications"" a
        ON a.""Id"" = mo.""ApplicationId""
    JOIN ""Menu"" me
        ON me.""Id"" = Mo.""MenuId""
    WHERE ur.""UserId"" = @p_user_id;
END;
            ");
        }
    }
}
