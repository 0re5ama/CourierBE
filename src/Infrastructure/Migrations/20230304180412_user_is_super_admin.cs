using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class user_is_super_admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_RoleId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "RoleUser",
                newName: "RolesId");

            migrationBuilder.AddColumn<bool>(
                name: "IsSuperAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_RolesId",
                table: "RoleUser",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_RolesId",
                table: "RoleUser");

            migrationBuilder.DropColumn(
                name: "IsSuperAdmin",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "RoleUser",
                newName: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_RoleId",
                table: "RoleUser",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
