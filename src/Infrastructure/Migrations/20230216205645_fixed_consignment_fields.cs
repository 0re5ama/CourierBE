using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class fixed_consignment_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsignmentItems_Items_ItemId",
                table: "ConsignmentItems");

            migrationBuilder.DropColumn(
                name: "CBM",
                table: "Consignments");

            migrationBuilder.AddColumn<decimal>(
                name: "Volume",
                table: "Consignments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "ConsignmentItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsignmentItems_Items_ItemId",
                table: "ConsignmentItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsignmentItems_Items_ItemId",
                table: "ConsignmentItems");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Consignments");

            migrationBuilder.AddColumn<string>(
                name: "CBM",
                table: "Consignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "ConsignmentItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsignmentItems_Items_ItemId",
                table: "ConsignmentItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
