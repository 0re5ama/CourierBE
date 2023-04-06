using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class menu_table_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasChild",
                table: "Menu");

            migrationBuilder.Sql($@"update ""Menu"" set SecApl = case SecApl when 'Y' then '1' else '0' end;");

            migrationBuilder.AlterColumn<bool>(
                name: "SecApl",
                table: "Menu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("0365f4a8-1574-42bd-a331-4e160c6c40ed"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("05a9b8bd-e08b-4493-b7fd-f47602b63ca8"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("2cf6f49d-69a6-47d7-a473-58d941538bab"),
                column: "SecApl",
                value: false);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("400f7539-aa3e-459c-9159-154759fd5e12"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("412d4976-15b3-451c-9ddd-1fda0ae45fb1"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("49b12a5a-6e12-48d2-bd86-8e83382ca4e7"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("807041f5-a442-422c-94c7-0065e46c483c"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8a314e94-1102-4b65-a2a9-9552133cf10f"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8b52e051-0d8b-49ff-a515-53b2ad9a9975"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("a779afac-05fa-4334-9b6b-2ede4a925cd4"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("b9019358-a9f8-4f29-b6f3-e9ca572bbab7"),
                column: "SecApl",
                value: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"),
                column: "SecApl",
                value: true);

            migrationBuilder.Sql($@"
ALTER PROCEDURE [cfn_get_user_menu]
	@p_user_id UNIQUEIDENTIFIER
AS
BEGIN
	with rtbl as (
	SELECT distinct me.""Id"" AS ""Id"",
        -- a.""Id"" AS ""ApplicationId"",
        me.""ToolTip"" AS ""Name"",
        me.""MUrl"" AS ""Path"",
        '.' + me.""MUrl"" AS ""Component"",
        me.""ParentId"" AS ""ParentId"",
        me.""Icon"" AS ""Icon"",
        me.OrderNo AS ""OrderNo"",
        null AS ""Routes""
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
    and me.""Active"" = 1
    union all
    select t.""Id"" AS ""Id"",
        -- a.""Id"" AS ""ApplicationId"",
        t.""ToolTip"" AS ""Name"",
        t.""MUrl"" AS ""Path"",
        '.' + t.""MUrl"" AS ""Component"",
        t.""ParentId"" AS ""ParentId"",
        t.""Icon"" AS ""Icon"",
        t.""OrderNo"" as ""OrderNo"",
        null AS ""Routes""
        from Menu t
        inner join rtbl r
        	on r.ParentId = t.Id
	)
	select distinct * from rtbl option(maxrecursion 0);   
END;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecApl",
                table: "Menu",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "HasChild",
                table: "Menu",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("0365f4a8-1574-42bd-a331-4e160c6c40ed"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("05a9b8bd-e08b-4493-b7fd-f47602b63ca8"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("2cf6f49d-69a6-47d7-a473-58d941538bab"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "N", "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("400f7539-aa3e-459c-9159-154759fd5e12"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("412d4976-15b3-451c-9ddd-1fda0ae45fb1"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("49b12a5a-6e12-48d2-bd86-8e83382ca4e7"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("807041f5-a442-422c-94c7-0065e46c483c"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8a314e94-1102-4b65-a2a9-9552133cf10f"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8b52e051-0d8b-49ff-a515-53b2ad9a9975"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("a779afac-05fa-4334-9b6b-2ede4a925cd4"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("b9019358-a9f8-4f29-b6f3-e9ca572bbab7"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"),
                columns: new[] { "HasChild", "SecApl" },
                values: new object[] { "Y", "Y" });

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
    }
}
