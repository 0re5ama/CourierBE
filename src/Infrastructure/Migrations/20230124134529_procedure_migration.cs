using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class procedure_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
CREATE PROCEDURE [cfn_get_user_menu]
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

            migrationBuilder.Sql($@"
CREATE PROCEDURE [cfn_get_user_applications]
	@p_user_id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT DISTINCT a.[Id],
		a.[Name],
		a.[Desc]
	FROM ""UserRoles"" ur
    JOIN ""Roles"" r
        ON r.""Id"" = ur.""RoleId""
    JOIN ""RoleModuleFunctions"" rmf
        ON rmf.""RoleId"" = ur.""RoleId""
            OR r.""Name"" = 'Admin'
    JOIN ""Functions"" f
        ON f.""Id"" = rmf.""ModuleFunctionId""
    JOIN ""Modules"" mo
        ON mo.""Id"" = f.""ModuleId""
    JOIN ""Applications"" a
        ON a.""Id"" = mo.""ApplicationId""
    WHERE ur.""UserId"" = @p_user_id;
END;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop procedure [dbo].[cfn_get_user_applications]");
            migrationBuilder.Sql("drop procedure [dbo].[cfn_get_user_menu]");
        }
    }
}
