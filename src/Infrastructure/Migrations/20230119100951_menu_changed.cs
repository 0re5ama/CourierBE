using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class menu_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: new Guid("306fa819-2903-413f-8e36-17c089d4d1a1"));

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: new Guid("5d8355ed-2339-460a-9c97-0938bb87f858"));

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: new Guid("a4df18fe-3f8b-49ad-b560-b18f42a82bd1"));

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: new Guid("c0bf73e0-2fb9-47aa-9b96-9afe13b636af"));

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: new Guid("df052f18-d397-4331-846e-34287180ede6"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de"));

            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("43476d5c-7d71-43bf-8ce3-6d78597b4765"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("0365f4a8-1574-42bd-a331-4e160c6c40ed"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/SearchConsignment", "SearchConsignment", 4, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("05a9b8bd-e08b-4493-b7fd-f47602b63ca8"),
                columns: new[] { "HasChild", "MUrl", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/Package", 10, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/Consignment", "ConsignmnetEntry", 3, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("400f7539-aa3e-459c-9159-154759fd5e12"),
                columns: new[] { "HasChild", "MUrl", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/Payment", 11, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("412d4976-15b3-451c-9ddd-1fda0ae45fb1"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/ItemList", "ItemList", 8, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"),
                column: "OrderNo",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("807041f5-a442-422c-94c7-0065e46c483c"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/ItemGroup", "ItemGroup", 7, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8a314e94-1102-4b65-a2a9-9552133cf10f"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/AdminDashboard", "AdminDashboard", 1, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8b52e051-0d8b-49ff-a515-53b2ad9a9975"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/CheckpointUserDashboard", "CheckpointUserDashboard", 2, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("a779afac-05fa-4334-9b6b-2ede4a925cd4"),
                column: "MUrl",
                value: "/Security/Role");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"),
                columns: new[] { "HasChild", "MUrl", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/Checkpoint", 9, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("b9019358-a9f8-4f29-b6f3-e9ca572bbab7"),
                columns: new[] { "HasChild", "MUrl", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/Container", 6, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "Y", "/ProductTracking/ContainerList", "ContainerList", 5, new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "HasChild", "Icon", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl", "ToolTip", "UsedIn" },
                values: new object[] { new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"), "Y", "form", null, "ProductTracking", 3, null, "Y", "productTracking", null });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: new Guid("187cda14-9844-42e7-99ba-b8d4f0d59c3a"),
                columns: new[] { "Address", "Code", "Contact", "EntryDate", "NameEng", "NameNep", "NameShort", "UpdatedDate" },
                values: new object[] { "Yuwi", "ADO", "ADO@gmail.com", new DateTime(2023, 1, 19, 15, 54, 49, 408, DateTimeKind.Local).AddTicks(2377), "ADO Logistics", "ADO Logistics", "ADO", new DateTime(2023, 1, 19, 15, 54, 49, 408, DateTimeKind.Local).AddTicks(8744) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1887fc0-caf5-4b3d-9930-525c8d296e05"),
                columns: new[] { "ConcurrencyStamp", "EntryDate" },
                values: new object[] { "df299433-0a3f-4154-bb1e-e9ccecbc09e8", new DateTime(2023, 1, 19, 10, 9, 49, 407, DateTimeKind.Utc).AddTicks(8373) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("5dd87968-fba4-43f5-b61d-75e705be1f9f"));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("0365f4a8-1574-42bd-a331-4e160c6c40ed"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", "/search-consignment", "Search Consignment", 6, new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"), "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("05a9b8bd-e08b-4493-b7fd-f47602b63ca8"),
                columns: new[] { "HasChild", "MUrl", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", "/package", 12, null, "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", "/consignment-entry", "Consignmnet Entry", 4, null, "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("400f7539-aa3e-459c-9159-154759fd5e12"),
                columns: new[] { "HasChild", "MUrl", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", null, 13, null, "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("412d4976-15b3-451c-9ddd-1fda0ae45fb1"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", "/itemList", "Item List", 10, null, "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"),
                column: "OrderNo",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("807041f5-a442-422c-94c7-0065e46c483c"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", "/itemGroup", "Item Group", 9, null, "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8a314e94-1102-4b65-a2a9-9552133cf10f"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", null, "Admin Dashboard", 2, null, "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("8b52e051-0d8b-49ff-a515-53b2ad9a9975"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", null, "Checkpoint User Dashboard", 14, null, "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("a779afac-05fa-4334-9b6b-2ede4a925cd4"),
                column: "MUrl",
                value: "/Security/role");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"),
                columns: new[] { "HasChild", "MUrl", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", "/checkpoints", 11, null, "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("b9019358-a9f8-4f29-b6f3-e9ca572bbab7"),
                columns: new[] { "HasChild", "MUrl", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", "/container", 8, new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"), "N" });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "Id",
                keyValue: new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"),
                columns: new[] { "HasChild", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl" },
                values: new object[] { "N", "/containerList", "Container List", 7, null, "N" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "HasChild", "Icon", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl", "ToolTip", "UsedIn" },
                values: new object[] { new Guid("43476d5c-7d71-43bf-8ce3-6d78597b4765"), "N", "form", null, "Consignment Remarks", 5, null, "N", "Consignment Remarks", null });

            migrationBuilder.UpdateData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: new Guid("187cda14-9844-42e7-99ba-b8d4f0d59c3a"),
                columns: new[] { "Address", "Code", "Contact", "EntryDate", "NameEng", "NameNep", "NameShort", "UpdatedDate" },
                values: new object[] { "Baneshwor", "Test", "nirvan@gmail.com", new DateTime(2023, 1, 17, 19, 30, 50, 21, DateTimeKind.Local).AddTicks(830), "Test Organization", "Test Organization", "Test", new DateTime(2023, 1, 17, 19, 30, 50, 22, DateTimeKind.Local).AddTicks(3124) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1887fc0-caf5-4b3d-9930-525c8d296e05"),
                columns: new[] { "ConcurrencyStamp", "EntryDate" },
                values: new object[] { "0bfc22f8-d5ee-47ed-aa92-b33f0a547c55", new DateTime(2023, 1, 17, 13, 45, 50, 20, DateTimeKind.Utc).AddTicks(5524) });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "ApplicationId", "Description", "FromDate", "MenuId", "Name", "ToDate" },
                values: new object[] { new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "Consignment Remarks", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("43476d5c-7d71-43bf-8ce3-6d78597b4765"), "Consignment Remarks", null });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "FunctionId", "ModuleId" },
                values: new object[,]
                {
                    { new Guid("306fa819-2903-413f-8e36-17c089d4d1a1"), 1, new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de") },
                    { new Guid("5d8355ed-2339-460a-9c97-0938bb87f858"), 2, new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de") },
                    { new Guid("a4df18fe-3f8b-49ad-b560-b18f42a82bd1"), 3, new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de") },
                    { new Guid("c0bf73e0-2fb9-47aa-9b96-9afe13b636af"), 4, new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de") },
                    { new Guid("df052f18-d397-4331-846e-34287180ede6"), 0, new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de") }
                });
        }
    }
}
