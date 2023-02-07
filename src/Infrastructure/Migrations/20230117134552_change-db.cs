using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductTracking.Infrastructure.Migrations
{
    public partial class changedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolTip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    MUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasChild = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    SecApl = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modules_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Functions_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationOffice",
                columns: table => new
                {
                    ApplicationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    officeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationOffice", x => new { x.ApplicationsId, x.officeId });
                    table.ForeignKey(
                        name: "FK_ApplicationOffice_Applications_ApplicationsId",
                        column: x => x.ApplicationsId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkpoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkpoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsignmentItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsignmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsignmentItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConsignmentNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsignmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Consignee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CtnNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expense = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CBM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Freight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreightPrePayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    freightDelivery = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Advance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Insurance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Prepayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TradeMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsignmentsStatus = table.Column<int>(type: "int", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: true),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consignments_Checkpoints_CurrentLocationId",
                        column: x => x.CurrentLocationId,
                        principalTable: "Checkpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consignments_Checkpoints_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Checkpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consignments_Checkpoints_StartingStationId",
                        column: x => x.StartingStationId,
                        principalTable: "Checkpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContainerConsignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConsignmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecivedStatus = table.Column<int>(type: "int", nullable: true),
                    RecivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerConsignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContainerConsignments_Consignments_ConsignmentId",
                        column: x => x.ConsignmentId,
                        principalTable: "Consignments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VechileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DriverContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsReceived = table.Column<bool>(type: "bit", nullable: true),
                    TransferContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Containers_Checkpoints_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Checkpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Containers_Checkpoints_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Checkpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Containers_Containers_TransferContainerId",
                        column: x => x.TransferContainerId,
                        principalTable: "Containers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HeaderContactDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConatactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderSNo = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderContactDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameShort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemGroups_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameNep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameShort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isParrent = table.Column<bool>(type: "bit", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    officeType = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_Offices_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EntryBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Functions_ModuleFunctionId",
                        column: x => x.ModuleFunctionId,
                        principalTable: "Functions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorizationNo = table.Column<int>(type: "int", nullable: true),
                    AuthorizedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorizationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasPasswordChanged = table.Column<bool>(type: "bit", nullable: false),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CheckpointId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Checkpoints_CheckpointId",
                        column: x => x.CheckpointId,
                        principalTable: "Checkpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleModule",
                columns: table => new
                {
                    ModulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModule", x => new { x.ModulesId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_RoleModule_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleModule_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleModuleFunctions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModuleFunctions", x => new { x.RoleId, x.ModuleFunctionId });
                    table.ForeignKey(
                        name: "FK_RoleModuleFunctions_Functions_ModuleFunctionId",
                        column: x => x.ModuleFunctionId,
                        principalTable: "Functions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleModuleFunctions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Users_EntryById",
                        column: x => x.EntryById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passwords_Users_EntryById",
                        column: x => x.EntryById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passwords_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Passwords_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RoleId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserModuleFunctions",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModuleFunctions", x => new { x.UserId, x.ModuleFunctionId });
                    table.ForeignKey(
                        name: "FK_UserModuleFunctions_Functions_ModuleFunctionId",
                        column: x => x.ModuleFunctionId,
                        principalTable: "Functions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserModuleFunctions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizationNo = table.Column<int>(type: "int", nullable: false),
                    AuthorizedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorizationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStatuses_Users_EntryById",
                        column: x => x.EntryById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStatuses_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserStatuses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Desc", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("541f2c3a-c67e-4b70-b58d-188486b7e04a"), "Security", "Security", null },
                    { new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "Product Tracking", "Product Tracking", null }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "HasChild", "Icon", "MUrl", "MenuText", "OrderNo", "ParentId", "SecApl", "ToolTip", "UsedIn" },
                values: new object[,]
                {
                    { new Guid("0365f4a8-1574-42bd-a331-4e160c6c40ed"), "N", "form", "/search-consignment", "Search Consignment", 6, new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"), "N", "Search Consignment", null },
                    { new Guid("05a9b8bd-e08b-4493-b7fd-f47602b63ca8"), "N", "form", "/package", "Package", 12, null, "N", "Package", null },
                    { new Guid("2cf6f49d-69a6-47d7-a473-58d941538bab"), "N", "smile", "/welcome", "Welcome", 1, null, "N", "Welcome", null },
                    { new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"), "N", "form", "/consignment-entry", "Consignmnet Entry", 4, null, "N", "ConsignmentEntry", null },
                    { new Guid("400f7539-aa3e-459c-9159-154759fd5e12"), "N", "form", null, "Payment", 13, null, "N", "Payment", null },
                    { new Guid("412d4976-15b3-451c-9ddd-1fda0ae45fb1"), "N", "form", "/itemList", "Item List", 10, null, "N", "Item List", null },
                    { new Guid("43476d5c-7d71-43bf-8ce3-6d78597b4765"), "N", "form", null, "Consignment Remarks", 5, null, "N", "Consignment Remarks", null },
                    { new Guid("49b12a5a-6e12-48d2-bd86-8e83382ca4e7"), "Y", "form", "/Security/Users", "Users", 1, new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"), "Y", "Users", null },
                    { new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"), "Y", "form", null, "Security", 3, null, "Y", "Security", null },
                    { new Guid("807041f5-a442-422c-94c7-0065e46c483c"), "N", "form", "/itemGroup", "Item Group", 9, null, "N", "Item Group", null },
                    { new Guid("8a314e94-1102-4b65-a2a9-9552133cf10f"), "N", "form", null, "Admin Dashboard", 2, null, "N", "Admin Dahboard", null },
                    { new Guid("8b52e051-0d8b-49ff-a515-53b2ad9a9975"), "N", "form", null, "Checkpoint User Dashboard", 14, null, "N", "Checkpoint User Dashboard", null },
                    { new Guid("a779afac-05fa-4334-9b6b-2ede4a925cd4"), "Y", "form", "/Security/role", "Role", 2, new Guid("78ce1776-2cee-43d8-892a-b9eabefea327"), "Y", "Role", null },
                    { new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"), "N", "form", "/checkpoints", "Checkpoints", 11, null, "N", "Checkpoints", null },
                    { new Guid("b9019358-a9f8-4f29-b6f3-e9ca572bbab7"), "N", "form", "/container", "Container", 8, new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"), "N", "Container", null },
                    { new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"), "N", "form", "/containerList", "Container List", 7, null, "N", "ContainerList", null }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Address", "Code", "Contact", "EntryById", "EntryDate", "Logo", "NameEng", "NameNep", "NameShort", "ParentId", "Status", "UpdatedById", "UpdatedDate", "Website", "isParrent", "officeType" },
                values: new object[] { new Guid("187cda14-9844-42e7-99ba-b8d4f0d59c3a"), "Baneshwor", "Test", "nirvan@gmail.com", null, new DateTime(2023, 1, 17, 19, 30, 50, 21, DateTimeKind.Local).AddTicks(830), null, "Test Organization", "Test Organization", "Test", null, 0, null, new DateTime(2023, 1, 17, 19, 30, 50, 22, DateTimeKind.Local).AddTicks(3124), null, false, 0 });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "ApplicationId", "Description", "FromDate", "MenuId", "Name", "ToDate" },
                values: new object[,]
                {
                    { new Guid("2776fcc6-9152-44dc-9eb3-09feb06f1e03"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "AdminDashboard", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("8a314e94-1102-4b65-a2a9-9552133cf10f"), "Admin Dashboard", null },
                    { new Guid("32f72f61-4b21-47ad-8ab5-87b12b3196cc"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "Payment", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("400f7539-aa3e-459c-9159-154759fd5e12"), "Payment ", null },
                    { new Guid("35fd9e2e-6647-4dc7-a18b-f7db036ee7c2"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "Container", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b9019358-a9f8-4f29-b6f3-e9ca572bbab7"), "Container", null },
                    { new Guid("3d829213-85e2-4562-82b8-2345fb90e3a1"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "Checkpoint User Dashboard", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("8b52e051-0d8b-49ff-a515-53b2ad9a9975"), "Checkpoint User Dashboard", null },
                    { new Guid("71a6e8c0-6347-4a57-9e0c-865f982d010e"), new Guid("541f2c3a-c67e-4b70-b58d-188486b7e04a"), "Role Management", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a779afac-05fa-4334-9b6b-2ede4a925cd4"), "Role", null },
                    { new Guid("80ab7bda-7402-43ff-97d0-054c62915190"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "Consignment Entry", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("32508cdc-db75-437e-bcc8-6cc67e2c82b2"), "Consignmnet", null },
                    { new Guid("8477d51f-980f-4dc5-8bdc-a94a40efad0c"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "Package", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("05a9b8bd-e08b-4493-b7fd-f47602b63ca8"), "Package ", null },
                    { new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "Consignment Remarks", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("43476d5c-7d71-43bf-8ce3-6d78597b4765"), "Consignment Remarks", null },
                    { new Guid("b70f5399-8929-4493-bcc3-75c38721ed21"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "Checkpoints", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("adab8a6c-7a06-48bd-b5eb-830be46c5d68"), "Checkpoints", null },
                    { new Guid("c48ccbd3-cbc1-4ce3-b64d-c77299b737d0"), new Guid("541f2c3a-c67e-4b70-b58d-188486b7e04a"), "User Management", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("49b12a5a-6e12-48d2-bd86-8e83382ca4e7"), "User", null },
                    { new Guid("d6ab380b-8a6d-4def-86b7-d28cbe3e734c"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "ContainerList", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d0ac4225-14f7-4b4c-bc0b-ecdfc6003d75"), "ContainerList ", null },
                    { new Guid("e0818357-af77-4a05-9879-3aeb0749ae0f"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "ItemGroups", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("807041f5-a442-422c-94c7-0065e46c483c"), "ItemGroups", null },
                    { new Guid("ed0ddce0-b06b-4915-aa79-bde61ac1a22f"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "SearchConsignment", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("0365f4a8-1574-42bd-a331-4e160c6c40ed"), "SearchConsignment", null },
                    { new Guid("f5bb0f10-1a8f-4398-bf07-c561c9257de4"), new Guid("9e936e4c-c13e-48ab-89b8-e7f72c1c658c"), "Item List", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("412d4976-15b3-451c-9ddd-1fda0ae45fb1"), "Item List", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AuthorizationDate", "AuthorizationNo", "AuthorizedBy", "CheckpointId", "ConcurrencyStamp", "Contact", "Email", "EmailConfirmed", "EmployeeId", "EntryBy", "EntryDate", "HasPasswordChanged", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "OfficeId", "Password", "PasswordHash", "PasswordResetToken", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { new Guid("d1887fc0-caf5-4b3d-9930-525c8d296e05"), 0, null, null, null, null, "0bfc22f8-d5ee-47ed-aa92-b33f0a547c55", null, "SuperAdmin", false, new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2023, 1, 17, 13, 45, 50, 20, DateTimeKind.Utc).AddTicks(5524), false, false, null, "info@superadmin.com", null, null, new Guid("187cda14-9844-42e7-99ba-b8d4f0d59c3a"), null, null, null, null, false, null, 0, false, null, "SuperAdmin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "FunctionId", "ModuleId" },
                values: new object[,]
                {
                    { new Guid("01149c07-9ce2-4be4-a7f9-0423329f234f"), 0, new Guid("ed0ddce0-b06b-4915-aa79-bde61ac1a22f") },
                    { new Guid("07f65903-2424-40a2-8ead-0f60e68b6eb8"), 4, new Guid("71a6e8c0-6347-4a57-9e0c-865f982d010e") },
                    { new Guid("16617fdd-323c-46eb-9032-73cab5421731"), 1, new Guid("c48ccbd3-cbc1-4ce3-b64d-c77299b737d0") },
                    { new Guid("175f94ae-def6-4a21-aedc-ffa1be5b7c30"), 3, new Guid("3d829213-85e2-4562-82b8-2345fb90e3a1") },
                    { new Guid("17f22f26-15a3-4a63-8144-e7d8d68d8364"), 0, new Guid("f5bb0f10-1a8f-4398-bf07-c561c9257de4") },
                    { new Guid("197bdd86-0969-4af2-afa1-d5d248009408"), 2, new Guid("3d829213-85e2-4562-82b8-2345fb90e3a1") },
                    { new Guid("1f4ed3e7-7ecc-4e56-9362-22c997c4fbed"), 4, new Guid("80ab7bda-7402-43ff-97d0-054c62915190") },
                    { new Guid("225fcfd8-08cd-4e95-8018-1be6d7ef81e6"), 0, new Guid("c48ccbd3-cbc1-4ce3-b64d-c77299b737d0") },
                    { new Guid("2372d3ef-4811-4f3b-a9e0-1b293ba8bf9d"), 0, new Guid("80ab7bda-7402-43ff-97d0-054c62915190") },
                    { new Guid("2a46bf6a-5c51-4e55-9b29-aca468dc7467"), 2, new Guid("80ab7bda-7402-43ff-97d0-054c62915190") },
                    { new Guid("306fa819-2903-413f-8e36-17c089d4d1a1"), 1, new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de") },
                    { new Guid("37a4300b-3d6c-4e1b-a0ed-3e42008d68aa"), 2, new Guid("71a6e8c0-6347-4a57-9e0c-865f982d010e") },
                    { new Guid("395e4c74-0f2e-47aa-93bf-397c8d94a624"), 4, new Guid("3d829213-85e2-4562-82b8-2345fb90e3a1") },
                    { new Guid("3a38bb4f-b1c8-4e25-9015-f5186d048af4"), 1, new Guid("ed0ddce0-b06b-4915-aa79-bde61ac1a22f") },
                    { new Guid("3bbb00d7-5111-4ae3-88ee-bbeaa647d10d"), 2, new Guid("b70f5399-8929-4493-bcc3-75c38721ed21") },
                    { new Guid("3d313b1e-b097-49a4-85c0-d1b1e7e588f6"), 1, new Guid("8477d51f-980f-4dc5-8bdc-a94a40efad0c") },
                    { new Guid("3fcf88d8-14da-4a11-8977-4612cfddaaed"), 1, new Guid("35fd9e2e-6647-4dc7-a18b-f7db036ee7c2") },
                    { new Guid("435fd0d5-85fe-4c13-a869-e14656157b8c"), 4, new Guid("35fd9e2e-6647-4dc7-a18b-f7db036ee7c2") },
                    { new Guid("441836a5-8a36-46f9-9ae8-9f685b70bfd9"), 0, new Guid("2776fcc6-9152-44dc-9eb3-09feb06f1e03") },
                    { new Guid("4d9503ae-6cf9-4f50-abff-e583c5e24572"), 4, new Guid("c48ccbd3-cbc1-4ce3-b64d-c77299b737d0") },
                    { new Guid("528d331f-409f-4b01-98d8-861218080a30"), 2, new Guid("32f72f61-4b21-47ad-8ab5-87b12b3196cc") },
                    { new Guid("53c400fd-ad21-42da-8326-dc3a7a69305f"), 2, new Guid("c48ccbd3-cbc1-4ce3-b64d-c77299b737d0") },
                    { new Guid("554b76c4-80ee-466f-a885-af387ef59e3b"), 4, new Guid("8477d51f-980f-4dc5-8bdc-a94a40efad0c") },
                    { new Guid("5555c4eb-50dc-4f9e-a3bc-18cf0acf270e"), 0, new Guid("d6ab380b-8a6d-4def-86b7-d28cbe3e734c") },
                    { new Guid("585c0c84-6e49-47a8-bf36-ba704b2d3c65"), 1, new Guid("b70f5399-8929-4493-bcc3-75c38721ed21") },
                    { new Guid("58d53946-a82a-463e-866c-10ed404fd123"), 0, new Guid("35fd9e2e-6647-4dc7-a18b-f7db036ee7c2") },
                    { new Guid("5d8355ed-2339-460a-9c97-0938bb87f858"), 2, new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de") },
                    { new Guid("6dfbf581-cea3-4a56-a8e7-2e915a12d424"), 3, new Guid("b70f5399-8929-4493-bcc3-75c38721ed21") },
                    { new Guid("6ee04b3b-7867-47bc-b77f-83882127dbba"), 0, new Guid("8477d51f-980f-4dc5-8bdc-a94a40efad0c") },
                    { new Guid("6fa727b1-f74d-4192-b94a-b7458ed0c1d6"), 3, new Guid("80ab7bda-7402-43ff-97d0-054c62915190") },
                    { new Guid("74d45031-0e89-48a1-817a-bc0b6bf9b451"), 1, new Guid("80ab7bda-7402-43ff-97d0-054c62915190") },
                    { new Guid("767cb5a3-687c-4c6a-a436-e533867b8a91"), 1, new Guid("e0818357-af77-4a05-9879-3aeb0749ae0f") },
                    { new Guid("7c0d7cd4-023d-4c44-b968-f9e12ee7bc05"), 3, new Guid("ed0ddce0-b06b-4915-aa79-bde61ac1a22f") },
                    { new Guid("7d44211e-63e3-459e-ac07-c282126c6ae4"), 0, new Guid("b70f5399-8929-4493-bcc3-75c38721ed21") },
                    { new Guid("8b8bee62-57dd-45da-9828-b8abed6ef140"), 1, new Guid("f5bb0f10-1a8f-4398-bf07-c561c9257de4") },
                    { new Guid("8c6ce7d6-c66f-4fe2-a02d-b145d18f71a5"), 3, new Guid("f5bb0f10-1a8f-4398-bf07-c561c9257de4") },
                    { new Guid("8f712a63-7f74-40aa-8c70-0a7d16c1d663"), 4, new Guid("b70f5399-8929-4493-bcc3-75c38721ed21") },
                    { new Guid("8fd30650-6ac2-418b-b85c-45bd613cccec"), 0, new Guid("e0818357-af77-4a05-9879-3aeb0749ae0f") },
                    { new Guid("913699eb-6ec7-428d-bd79-8e79a01d16c8"), 3, new Guid("e0818357-af77-4a05-9879-3aeb0749ae0f") },
                    { new Guid("93184797-0528-4ec5-86cb-faf7fc708cc9"), 3, new Guid("c48ccbd3-cbc1-4ce3-b64d-c77299b737d0") },
                    { new Guid("9fe41e12-cdf2-47a8-9785-4daabc79e2ad"), 1, new Guid("d6ab380b-8a6d-4def-86b7-d28cbe3e734c") },
                    { new Guid("a4df18fe-3f8b-49ad-b560-b18f42a82bd1"), 3, new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de") }
                });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "FunctionId", "ModuleId" },
                values: new object[,]
                {
                    { new Guid("a77c7b10-7425-4187-a071-18c560a497fc"), 2, new Guid("2776fcc6-9152-44dc-9eb3-09feb06f1e03") },
                    { new Guid("a8043dcd-dcd5-4490-9a71-800269326313"), 1, new Guid("71a6e8c0-6347-4a57-9e0c-865f982d010e") },
                    { new Guid("a85d4eb8-590b-4858-ab41-12143a7bdf2e"), 2, new Guid("ed0ddce0-b06b-4915-aa79-bde61ac1a22f") },
                    { new Guid("ab4fa3c9-d315-438c-baf7-fa685c9554ec"), 2, new Guid("f5bb0f10-1a8f-4398-bf07-c561c9257de4") },
                    { new Guid("ac2dfe0b-f376-43f2-876d-d21111f3bae2"), 3, new Guid("35fd9e2e-6647-4dc7-a18b-f7db036ee7c2") },
                    { new Guid("ad500926-6347-49a2-af43-6d2838eb2166"), 2, new Guid("35fd9e2e-6647-4dc7-a18b-f7db036ee7c2") },
                    { new Guid("af63eba7-64c2-4975-89ec-38c596e33b08"), 2, new Guid("e0818357-af77-4a05-9879-3aeb0749ae0f") },
                    { new Guid("b6f82e0c-b48c-4291-b241-a812967858d4"), 1, new Guid("3d829213-85e2-4562-82b8-2345fb90e3a1") },
                    { new Guid("bb1e94bc-b609-4b33-aa69-884c657719fb"), 3, new Guid("71a6e8c0-6347-4a57-9e0c-865f982d010e") },
                    { new Guid("bbe5ebc2-3f06-48b1-8f71-73f5f085f955"), 4, new Guid("f5bb0f10-1a8f-4398-bf07-c561c9257de4") },
                    { new Guid("bc175d7d-687e-40fe-a738-4282e8c0d4e6"), 0, new Guid("71a6e8c0-6347-4a57-9e0c-865f982d010e") },
                    { new Guid("bc52140f-e811-4ef3-87af-4164651f968d"), 4, new Guid("e0818357-af77-4a05-9879-3aeb0749ae0f") },
                    { new Guid("beb0076e-21f3-49f2-af06-fa61d7775eb2"), 4, new Guid("2776fcc6-9152-44dc-9eb3-09feb06f1e03") },
                    { new Guid("bf12e57d-3c29-46af-a10c-c39e3a9dad2f"), 4, new Guid("ed0ddce0-b06b-4915-aa79-bde61ac1a22f") },
                    { new Guid("bfb61e90-d5f7-4ebb-aa18-b318eb6528c4"), 2, new Guid("8477d51f-980f-4dc5-8bdc-a94a40efad0c") },
                    { new Guid("c0bf73e0-2fb9-47aa-9b96-9afe13b636af"), 4, new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de") },
                    { new Guid("cc30b194-e74f-48fc-b574-7fe74da24f7d"), 4, new Guid("32f72f61-4b21-47ad-8ab5-87b12b3196cc") },
                    { new Guid("d20b3676-08d0-47e5-9a78-a0531f3c0b8f"), 3, new Guid("32f72f61-4b21-47ad-8ab5-87b12b3196cc") },
                    { new Guid("d5576878-207e-4e0d-a193-65719e4f92f7"), 3, new Guid("8477d51f-980f-4dc5-8bdc-a94a40efad0c") },
                    { new Guid("d7b54046-e035-49d8-81cf-37e5011d3c6f"), 0, new Guid("3d829213-85e2-4562-82b8-2345fb90e3a1") },
                    { new Guid("d9e14acc-6aca-4adb-b61e-fa72bf3b1393"), 4, new Guid("d6ab380b-8a6d-4def-86b7-d28cbe3e734c") },
                    { new Guid("df052f18-d397-4331-846e-34287180ede6"), 0, new Guid("94e9e57d-c8d9-4a9a-87d4-fef0c9abe5de") },
                    { new Guid("eb1d9441-9f85-46e9-895f-882043c14922"), 3, new Guid("d6ab380b-8a6d-4def-86b7-d28cbe3e734c") },
                    { new Guid("edc9e686-bf21-4a32-8696-012ba360120f"), 3, new Guid("2776fcc6-9152-44dc-9eb3-09feb06f1e03") },
                    { new Guid("f1ef9408-04aa-446c-acf6-7e195b74ee64"), 1, new Guid("2776fcc6-9152-44dc-9eb3-09feb06f1e03") },
                    { new Guid("fb645f1a-7699-417f-8f83-f9c10dbe063d"), 2, new Guid("d6ab380b-8a6d-4def-86b7-d28cbe3e734c") },
                    { new Guid("fc7f12a9-8a1e-4afc-b505-f5753db019cc"), 1, new Guid("32f72f61-4b21-47ad-8ab5-87b12b3196cc") },
                    { new Guid("fffa286b-e580-45ec-a9f4-7b7b41b2e87b"), 0, new Guid("32f72f61-4b21-47ad-8ab5-87b12b3196cc") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationOffice_officeId",
                table: "ApplicationOffice",
                column: "officeId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_Name",
                table: "Applications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_EntryById",
                table: "Checkpoints",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_UpdatedById",
                table: "Checkpoints",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ConsignmentItems_ConsignmentId",
                table: "ConsignmentItems",
                column: "ConsignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsignmentItems_EntryById",
                table: "ConsignmentItems",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_ConsignmentItems_ItemId",
                table: "ConsignmentItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsignmentItems_UpdatedById",
                table: "ConsignmentItems",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_ContainerId",
                table: "Consignments",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_CurrentLocationId",
                table: "Consignments",
                column: "CurrentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_DestinationId",
                table: "Consignments",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_EntryById",
                table: "Consignments",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_PackageId",
                table: "Consignments",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_StartingStationId",
                table: "Consignments",
                column: "StartingStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consignments_UpdatedById",
                table: "Consignments",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerConsignments_ConsignmentId",
                table: "ContainerConsignments",
                column: "ConsignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerConsignments_ContainerId",
                table: "ContainerConsignments",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerConsignments_EntryById",
                table: "ContainerConsignments",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerConsignments_UpdatedById",
                table: "ContainerConsignments",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_DestinationId",
                table: "Containers",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_EntryById",
                table: "Containers",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_SourceId",
                table: "Containers",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_TransferContainerId",
                table: "Containers",
                column: "TransferContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_UpdatedById",
                table: "Containers",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Functions_ModuleId",
                table: "Functions",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_HeaderContactDetails_EntryById",
                table: "HeaderContactDetails",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_HeaderContactDetails_UpdatedById",
                table: "HeaderContactDetails",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_EntryById",
                table: "ItemGroups",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_UpdatedById",
                table: "ItemGroups",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Items_EntryById",
                table: "Items",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemGroupId",
                table: "Items",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UpdatedById",
                table: "Items",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LoginLogs_UserId",
                table: "LoginLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ApplicationId_Name",
                table: "Modules",
                columns: new[] { "ApplicationId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_MenuId",
                table: "Modules",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_EntryById",
                table: "Offices",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_ParentId",
                table: "Offices",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_UpdatedById",
                table: "Offices",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_EntryById",
                table: "Packages",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_UpdatedById",
                table: "Packages",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_EntryById",
                table: "Passwords",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_UpdatedById",
                table: "Passwords",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_userId",
                table: "Passwords",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModule_RolesId",
                table: "RoleModule",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModuleFunctions_ModuleFunctionId",
                table: "RoleModuleFunctions",
                column: "ModuleFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModuleFunctionId",
                table: "Roles",
                column: "ModuleFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_OfficeId",
                table: "Roles",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModuleFunctions_ModuleFunctionId",
                table: "UserModuleFunctions",
                column: "ModuleFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CheckpointId",
                table: "Users",
                column: "CheckpointId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OfficeId",
                table: "Users",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserStatuses_EntryById",
                table: "UserStatuses",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_UserStatuses_UpdatedById",
                table: "UserStatuses",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserStatuses_UserId",
                table: "UserStatuses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationOffice_Offices_officeId",
                table: "ApplicationOffice",
                column: "officeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkpoints_Users_EntryById",
                table: "Checkpoints",
                column: "EntryById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkpoints_Users_UpdatedById",
                table: "Checkpoints",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsignmentItems_Consignments_ConsignmentId",
                table: "ConsignmentItems",
                column: "ConsignmentId",
                principalTable: "Consignments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsignmentItems_Items_ItemId",
                table: "ConsignmentItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsignmentItems_Users_EntryById",
                table: "ConsignmentItems",
                column: "EntryById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsignmentItems_Users_UpdatedById",
                table: "ConsignmentItems",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consignments_Containers_ContainerId",
                table: "Consignments",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consignments_Packages_PackageId",
                table: "Consignments",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consignments_Users_EntryById",
                table: "Consignments",
                column: "EntryById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consignments_Users_UpdatedById",
                table: "Consignments",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerConsignments_Containers_ContainerId",
                table: "ContainerConsignments",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerConsignments_Users_EntryById",
                table: "ContainerConsignments",
                column: "EntryById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerConsignments_Users_UpdatedById",
                table: "ContainerConsignments",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Users_EntryById",
                table: "Containers",
                column: "EntryById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Users_UpdatedById",
                table: "Containers",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HeaderContactDetails_Users_EntryById",
                table: "HeaderContactDetails",
                column: "EntryById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HeaderContactDetails_Users_UpdatedById",
                table: "HeaderContactDetails",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemGroups_Users_EntryById",
                table: "ItemGroups",
                column: "EntryById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemGroups_Users_UpdatedById",
                table: "ItemGroups",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_EntryById",
                table: "Items",
                column: "EntryById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UpdatedById",
                table: "Items",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginLogs_Users_UserId",
                table: "LoginLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Users_EntryById",
                table: "Offices",
                column: "EntryById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Users_UpdatedById",
                table: "Offices",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Offices_OfficeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkpoints_Users_EntryById",
                table: "Checkpoints");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkpoints_Users_UpdatedById",
                table: "Checkpoints");

            migrationBuilder.DropTable(
                name: "ApplicationOffice");

            migrationBuilder.DropTable(
                name: "ConsignmentItems");

            migrationBuilder.DropTable(
                name: "ContainerConsignments");

            migrationBuilder.DropTable(
                name: "HeaderContactDetails");

            migrationBuilder.DropTable(
                name: "LoginLogs");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "RoleModule");

            migrationBuilder.DropTable(
                name: "RoleModuleFunctions");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserModuleFunctions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserStatuses");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Consignments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Checkpoints");
        }
    }
}
