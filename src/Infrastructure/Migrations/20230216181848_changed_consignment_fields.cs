using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class changed_consignment_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expense",
                table: "Consignments");

            migrationBuilder.DropColumn(
                name: "FreightPrePayment",
                table: "Consignments");

            migrationBuilder.DropColumn(
                name: "Prepayment",
                table: "Consignments");

            migrationBuilder.RenameColumn(
                name: "freightDelivery",
                table: "Consignments",
                newName: "PackingFee");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Consignments",
                newName: "LocalFreight");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Consignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "ConsignmentItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql($@"
create sequence seq_consignment_no
start with 1
increment by 1;
            ");

            migrationBuilder.Sql($@"
create procedure gen_consignment_no
as
declare @curr_year int = year(getdate());
begin
	if ((
		select count(*)
		from Consignments
		where year(ConsignmentDate)  = @curr_year
		) = 0
	)
		alter sequence seq_consignment_no
		restart with 1
		increment by 1;
	
	select
		substring(cast(@curr_year as varchar(4)), 3, 4)
		+ '-'
		+ right('00000' + cast(NEXT VALUE FOR seq_consignment_no as varchar(6)), 6);
end;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Consignments");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "ConsignmentItems");

            migrationBuilder.RenameColumn(
                name: "PackingFee",
                table: "Consignments",
                newName: "freightDelivery");

            migrationBuilder.RenameColumn(
                name: "LocalFreight",
                table: "Consignments",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "Expense",
                table: "Consignments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FreightPrePayment",
                table: "Consignments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prepayment",
                table: "Consignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql($@"
drop procedure gen_consignment_no;
drop sequence seq_consignment_no;
            ");
        }
    }
}
