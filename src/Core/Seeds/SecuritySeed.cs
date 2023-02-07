using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Entities.Settings;
using ProductTracking.Core.Enums.Security;

namespace ProductTracking.Core.Seeds;
public static class SecuritySeed
{


    public static List<Office> Offices = new List<Office>()
    {
        new Office("187cda14-9844-42e7-99ba-b8d4f0d59c3a", "ADO Logistics", "ADO", "Yuwi", "ADO@gmail.com",new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc)),
    };

    public static List<Application> Applications = new List<Application>()
    {
        new Application("541f2c3a-c67e-4b70-b58d-188486b7e04a", "Security", "Security"),
        new Application("9e936e4c-c13e-48ab-89b8-e7f72c1c658c","Product Tracking","Product Tracking")

    };

    public static List<Module> Modules = new List<Module>()
    {
        new Module("c48ccbd3-cbc1-4ce3-b64d-c77299b737d0", "541f2c3a-c67e-4b70-b58d-188486b7e04a", "User", "User Management", new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc), "49b12a5a-6e12-48d2-bd86-8e83382ca4e7"),
        new Module("71a6e8c0-6347-4a57-9e0c-865f982d010e", "541f2c3a-c67e-4b70-b58d-188486b7e04a", "Role", "Role Management", new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc), "a779afac-05fa-4334-9b6b-2ede4a925cd4"),
        new Module("80ab7bda-7402-43ff-97d0-054c62915190","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","Consignmnet","Consignment Entry",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"32508cdc-db75-437e-bcc8-6cc67e2c82b2"),
        new Module("35fd9e2e-6647-4dc7-a18b-f7db036ee7c2","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","Container","Container",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"b9019358-a9f8-4f29-b6f3-e9ca572bbab7"),
        new Module("d6ab380b-8a6d-4def-86b7-d28cbe3e734c","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","ContainerList ","ContainerList",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"),
        new Module("8477d51f-980f-4dc5-8bdc-a94a40efad0c","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","Package ","Package",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"05a9b8bd-e08b-4493-b7fd-f47602b63ca8"),
        new Module("32f72f61-4b21-47ad-8ab5-87b12b3196cc","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","Payment ","Payment",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"400f7539-aa3e-459c-9159-154759fd5e12"),
        new Module("ed0ddce0-b06b-4915-aa79-bde61ac1a22f","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","SearchConsignment","SearchConsignment",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"0365f4a8-1574-42bd-a331-4e160c6c40ed"),
        new Module("2776fcc6-9152-44dc-9eb3-09feb06f1e03","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","Admin Dashboard","AdminDashboard",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"8a314e94-1102-4b65-a2a9-9552133cf10f"),
        new Module("3d829213-85e2-4562-82b8-2345fb90e3a1","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","Checkpoint User Dashboard","Checkpoint User Dashboard",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"8b52e051-0d8b-49ff-a515-53b2ad9a9975"),
        new Module("f5bb0f10-1a8f-4398-bf07-c561c9257de4","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","Item List","Item List",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"412d4976-15b3-451c-9ddd-1fda0ae45fb1"),
        new Module("b70f5399-8929-4493-bcc3-75c38721ed21","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","Checkpoints","Checkpoints",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"adab8a6c-7a06-48bd-b5eb-830be46c5d68"),
        new Module("e0818357-af77-4a05-9879-3aeb0749ae0f","9e936e4c-c13e-48ab-89b8-e7f72c1c658c","ItemGroups","ItemGroups",  new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc),"807041f5-a442-422c-94c7-0065e46c483c"),

    };

    public static List<ModuleFunction> ModuleFunctions = new List<ModuleFunction>()
    {
        new ModuleFunction("225fcfd8-08cd-4e95-8018-1be6d7ef81e6", "c48ccbd3-cbc1-4ce3-b64d-c77299b737d0", EnFunction.Read),
        new ModuleFunction("16617fdd-323c-46eb-9032-73cab5421731", "c48ccbd3-cbc1-4ce3-b64d-c77299b737d0", EnFunction.Write),
        new ModuleFunction("53c400fd-ad21-42da-8326-dc3a7a69305f", "c48ccbd3-cbc1-4ce3-b64d-c77299b737d0", EnFunction.Update),
        new ModuleFunction("93184797-0528-4ec5-86cb-faf7fc708cc9", "c48ccbd3-cbc1-4ce3-b64d-c77299b737d0", EnFunction.Delete),
        new ModuleFunction("4d9503ae-6cf9-4f50-abff-e583c5e24572", "c48ccbd3-cbc1-4ce3-b64d-c77299b737d0", EnFunction.Report),
        new ModuleFunction("bc175d7d-687e-40fe-a738-4282e8c0d4e6", "71a6e8c0-6347-4a57-9e0c-865f982d010e", EnFunction.Read),
        new ModuleFunction("a8043dcd-dcd5-4490-9a71-800269326313", "71a6e8c0-6347-4a57-9e0c-865f982d010e", EnFunction.Write),
        new ModuleFunction("37a4300b-3d6c-4e1b-a0ed-3e42008d68aa", "71a6e8c0-6347-4a57-9e0c-865f982d010e", EnFunction.Update),
        new ModuleFunction("bb1e94bc-b609-4b33-aa69-884c657719fb", "71a6e8c0-6347-4a57-9e0c-865f982d010e", EnFunction.Delete),
        new ModuleFunction("07f65903-2424-40a2-8ead-0f60e68b6eb8", "71a6e8c0-6347-4a57-9e0c-865f982d010e", EnFunction.Report),
        new ModuleFunction("2372d3ef-4811-4f3b-a9e0-1b293ba8bf9d", "80ab7bda-7402-43ff-97d0-054c62915190", EnFunction.Read),
        new ModuleFunction("74d45031-0e89-48a1-817a-bc0b6bf9b451", "80ab7bda-7402-43ff-97d0-054c62915190", EnFunction.Write),
        new ModuleFunction("2a46bf6a-5c51-4e55-9b29-aca468dc7467", "80ab7bda-7402-43ff-97d0-054c62915190", EnFunction.Update),
        new ModuleFunction("6fa727b1-f74d-4192-b94a-b7458ed0c1d6", "80ab7bda-7402-43ff-97d0-054c62915190", EnFunction.Delete),
        new ModuleFunction("1f4ed3e7-7ecc-4e56-9362-22c997c4fbed", "80ab7bda-7402-43ff-97d0-054c62915190", EnFunction.Report),
        new ModuleFunction("58d53946-a82a-463e-866c-10ed404fd123", "35fd9e2e-6647-4dc7-a18b-f7db036ee7c2", EnFunction.Read),
        new ModuleFunction("3fcf88d8-14da-4a11-8977-4612cfddaaed", "35fd9e2e-6647-4dc7-a18b-f7db036ee7c2", EnFunction.Write),
        new ModuleFunction("ad500926-6347-49a2-af43-6d2838eb2166", "35fd9e2e-6647-4dc7-a18b-f7db036ee7c2", EnFunction.Update),
        new ModuleFunction("ac2dfe0b-f376-43f2-876d-d21111f3bae2", "35fd9e2e-6647-4dc7-a18b-f7db036ee7c2", EnFunction.Delete),
        new ModuleFunction("435fd0d5-85fe-4c13-a869-e14656157b8c", "35fd9e2e-6647-4dc7-a18b-f7db036ee7c2", EnFunction.Report),
        new ModuleFunction("5555c4eb-50dc-4f9e-a3bc-18cf0acf270e", "d6ab380b-8a6d-4def-86b7-d28cbe3e734c", EnFunction.Read),
        new ModuleFunction("9fe41e12-cdf2-47a8-9785-4daabc79e2ad", "d6ab380b-8a6d-4def-86b7-d28cbe3e734c", EnFunction.Write),
        new ModuleFunction("fb645f1a-7699-417f-8f83-f9c10dbe063d", "d6ab380b-8a6d-4def-86b7-d28cbe3e734c", EnFunction.Update),
        new ModuleFunction("eb1d9441-9f85-46e9-895f-882043c14922", "d6ab380b-8a6d-4def-86b7-d28cbe3e734c", EnFunction.Delete),
        new ModuleFunction("d9e14acc-6aca-4adb-b61e-fa72bf3b1393", "d6ab380b-8a6d-4def-86b7-d28cbe3e734c", EnFunction.Report),
        new ModuleFunction("6ee04b3b-7867-47bc-b77f-83882127dbba", "8477d51f-980f-4dc5-8bdc-a94a40efad0c", EnFunction.Read),
        new ModuleFunction("3d313b1e-b097-49a4-85c0-d1b1e7e588f6", "8477d51f-980f-4dc5-8bdc-a94a40efad0c", EnFunction.Write),
        new ModuleFunction("bfb61e90-d5f7-4ebb-aa18-b318eb6528c4", "8477d51f-980f-4dc5-8bdc-a94a40efad0c", EnFunction.Update),
        new ModuleFunction("d5576878-207e-4e0d-a193-65719e4f92f7", "8477d51f-980f-4dc5-8bdc-a94a40efad0c", EnFunction.Delete),
        new ModuleFunction("554b76c4-80ee-466f-a885-af387ef59e3b", "8477d51f-980f-4dc5-8bdc-a94a40efad0c", EnFunction.Report),
         new ModuleFunction("fffa286b-e580-45ec-a9f4-7b7b41b2e87b","32f72f61-4b21-47ad-8ab5-87b12b3196cc", EnFunction.Read),
        new ModuleFunction("fc7f12a9-8a1e-4afc-b505-f5753db019cc", "32f72f61-4b21-47ad-8ab5-87b12b3196cc", EnFunction.Write),
        new ModuleFunction("528d331f-409f-4b01-98d8-861218080a30", "32f72f61-4b21-47ad-8ab5-87b12b3196cc", EnFunction.Update),
        new ModuleFunction("d20b3676-08d0-47e5-9a78-a0531f3c0b8f", "32f72f61-4b21-47ad-8ab5-87b12b3196cc", EnFunction.Delete),
        new ModuleFunction("cc30b194-e74f-48fc-b574-7fe74da24f7d", "32f72f61-4b21-47ad-8ab5-87b12b3196cc", EnFunction.Report),
        new ModuleFunction("01149c07-9ce2-4be4-a7f9-0423329f234f", "ed0ddce0-b06b-4915-aa79-bde61ac1a22f", EnFunction.Read),
        new ModuleFunction("3a38bb4f-b1c8-4e25-9015-f5186d048af4", "ed0ddce0-b06b-4915-aa79-bde61ac1a22f", EnFunction.Write),
        new ModuleFunction("a85d4eb8-590b-4858-ab41-12143a7bdf2e", "ed0ddce0-b06b-4915-aa79-bde61ac1a22f", EnFunction.Update),
        new ModuleFunction("7c0d7cd4-023d-4c44-b968-f9e12ee7bc05", "ed0ddce0-b06b-4915-aa79-bde61ac1a22f", EnFunction.Delete),
        new ModuleFunction("bf12e57d-3c29-46af-a10c-c39e3a9dad2f", "ed0ddce0-b06b-4915-aa79-bde61ac1a22f", EnFunction.Report),
        new ModuleFunction("441836a5-8a36-46f9-9ae8-9f685b70bfd9", "2776fcc6-9152-44dc-9eb3-09feb06f1e03", EnFunction.Read),
        new ModuleFunction("f1ef9408-04aa-446c-acf6-7e195b74ee64", "2776fcc6-9152-44dc-9eb3-09feb06f1e03", EnFunction.Write),
        new ModuleFunction("a77c7b10-7425-4187-a071-18c560a497fc", "2776fcc6-9152-44dc-9eb3-09feb06f1e03", EnFunction.Update),
        new ModuleFunction("edc9e686-bf21-4a32-8696-012ba360120f", "2776fcc6-9152-44dc-9eb3-09feb06f1e03", EnFunction.Delete),
        new ModuleFunction("beb0076e-21f3-49f2-af06-fa61d7775eb2", "2776fcc6-9152-44dc-9eb3-09feb06f1e03", EnFunction.Report),
        new ModuleFunction("d7b54046-e035-49d8-81cf-37e5011d3c6f", "3d829213-85e2-4562-82b8-2345fb90e3a1", EnFunction.Read),
        new ModuleFunction("b6f82e0c-b48c-4291-b241-a812967858d4", "3d829213-85e2-4562-82b8-2345fb90e3a1", EnFunction.Write),
        new ModuleFunction("197bdd86-0969-4af2-afa1-d5d248009408", "3d829213-85e2-4562-82b8-2345fb90e3a1", EnFunction.Update),
        new ModuleFunction("175f94ae-def6-4a21-aedc-ffa1be5b7c30", "3d829213-85e2-4562-82b8-2345fb90e3a1", EnFunction.Delete),
        new ModuleFunction("395e4c74-0f2e-47aa-93bf-397c8d94a624", "3d829213-85e2-4562-82b8-2345fb90e3a1", EnFunction.Report),
        new ModuleFunction("17f22f26-15a3-4a63-8144-e7d8d68d8364", "f5bb0f10-1a8f-4398-bf07-c561c9257de4", EnFunction.Read),
        new ModuleFunction("8b8bee62-57dd-45da-9828-b8abed6ef140", "f5bb0f10-1a8f-4398-bf07-c561c9257de4", EnFunction.Write),
        new ModuleFunction("ab4fa3c9-d315-438c-baf7-fa685c9554ec", "f5bb0f10-1a8f-4398-bf07-c561c9257de4", EnFunction.Update),
        new ModuleFunction("8c6ce7d6-c66f-4fe2-a02d-b145d18f71a5", "f5bb0f10-1a8f-4398-bf07-c561c9257de4", EnFunction.Delete),
        new ModuleFunction("bbe5ebc2-3f06-48b1-8f71-73f5f085f955", "f5bb0f10-1a8f-4398-bf07-c561c9257de4", EnFunction.Report),
        new ModuleFunction("7d44211e-63e3-459e-ac07-c282126c6ae4", "b70f5399-8929-4493-bcc3-75c38721ed21", EnFunction.Read),
        new ModuleFunction("585c0c84-6e49-47a8-bf36-ba704b2d3c65", "b70f5399-8929-4493-bcc3-75c38721ed21", EnFunction.Write),
        new ModuleFunction("3bbb00d7-5111-4ae3-88ee-bbeaa647d10d", "b70f5399-8929-4493-bcc3-75c38721ed21", EnFunction.Update),
        new ModuleFunction("6dfbf581-cea3-4a56-a8e7-2e915a12d424", "b70f5399-8929-4493-bcc3-75c38721ed21", EnFunction.Delete),
        new ModuleFunction("8f712a63-7f74-40aa-8c70-0a7d16c1d663", "b70f5399-8929-4493-bcc3-75c38721ed21", EnFunction.Report),
        new ModuleFunction("8fd30650-6ac2-418b-b85c-45bd613cccec", "e0818357-af77-4a05-9879-3aeb0749ae0f", EnFunction.Read),
        new ModuleFunction("767cb5a3-687c-4c6a-a436-e533867b8a91", "e0818357-af77-4a05-9879-3aeb0749ae0f", EnFunction.Write),
        new ModuleFunction("af63eba7-64c2-4975-89ec-38c596e33b08", "e0818357-af77-4a05-9879-3aeb0749ae0f", EnFunction.Update),
        new ModuleFunction("913699eb-6ec7-428d-bd79-8e79a01d16c8", "e0818357-af77-4a05-9879-3aeb0749ae0f", EnFunction.Delete),
        new ModuleFunction("bc52140f-e811-4ef3-87af-4164651f968d", "e0818357-af77-4a05-9879-3aeb0749ae0f", EnFunction.Report),


    };
    public static List<Menu> Menus = new List<Menu>()
    {
        new Menu("2cf6f49d-69a6-47d7-a473-58d941538bab", "Welcome", "Welcome", null, 1, "/welcome", null, 'N', 'N', "smile"),
        new Menu("78ce1776-2cee-43d8-892a-b9eabefea327", "Security", "Security", null, 2, null, null, 'Y', 'Y', "form"),
        new Menu("49b12a5a-6e12-48d2-bd86-8e83382ca4e7", "Users", "Users", null, 1, "/Security/Users", "78ce1776-2cee-43d8-892a-b9eabefea327", 'Y', 'Y', "form"),
        new Menu("a779afac-05fa-4334-9b6b-2ede4a925cd4", "Role", "Role", null, 2, "/Security/Role", "78ce1776-2cee-43d8-892a-b9eabefea327", 'Y', 'Y', "form"),
        new Menu("5dd87968-fba4-43f5-b61d-75e705be1f9f", "ProductTracking", "productTracking", null, 3, null, null, 'Y', 'Y', "form"),
        new Menu("8a314e94-1102-4b65-a2a9-9552133cf10f", "AdminDashboard", "Admin Dahboard", null, 1, "/ProductTracking/AdminDashboard", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),
        new Menu("8b52e051-0d8b-49ff-a515-53b2ad9a9975", "CheckpointUserDashboard", "Checkpoint User Dashboard", null, 2, "/ProductTracking/CheckpointUserDashboard", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),
        new Menu("32508cdc-db75-437e-bcc8-6cc67e2c82b2", "ConsignmnetEntry", "ConsignmentEntry", null, 3, "/ProductTracking/Consignment", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),
        new Menu("0365f4a8-1574-42bd-a331-4e160c6c40ed", "SearchConsignment", "Search Consignment", null, 4, "/ProductTracking/SearchConsignment", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),
        new Menu("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75", "ContainerList", "ContainerList", null, 5, "/ProductTracking/ContainerList", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),
        new Menu("b9019358-a9f8-4f29-b6f3-e9ca572bbab7", "Container", "Container", null, 6, "/ProductTracking/Container", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),
        new Menu("807041f5-a442-422c-94c7-0065e46c483c", "ItemGroup", "Item Group", null, 7, "/ProductTracking/ItemGroup", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),
        new Menu("412d4976-15b3-451c-9ddd-1fda0ae45fb1", "ItemList", "Item List", null, 8, "/ProductTracking/ItemList", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),
        new Menu("adab8a6c-7a06-48bd-b5eb-830be46c5d68", "Checkpoints", "Checkpoints", null, 9, "/ProductTracking/Checkpoint", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),
        new Menu("05a9b8bd-e08b-4493-b7fd-f47602b63ca8", "Package", "Package", null, 10, "/ProductTracking/Package", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),
        new Menu("400f7539-aa3e-459c-9159-154759fd5e12", "Payment", "Payment", null, 11, "/ProductTracking/Payment", "5dd87968-fba4-43f5-b61d-75e705be1f9f", 'Y', 'Y', "form"),

    };

}
