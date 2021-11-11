using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VoipProjectEntities.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentCustomers",
                columns: table => new
                {
                    AgentCustomerID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    AgentName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ISMigratedAt = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentCustomers", x => x.AgentCustomerID);
                    table.ForeignKey(
                        name: "FK_AgentCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BalanceCustomers",
                columns: table => new
                {
                    BalanceCustomerID = table.Column<Guid>(nullable: false),
                    BalanceAmount = table.Column<double>(nullable: false),
                    TranscationType = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceCustomers", x => x.BalanceCustomerID);
                    table.ForeignKey(
                        name: "FK_BalanceCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "MenuAccesses",
                columns: table => new
                {
                    MenuAccessId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsAccess = table.Column<bool>(nullable: false),
                    MenuLink = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuAccesses", x => x.MenuAccessId);
                    table.ForeignKey(
                       name: "FK_MenuAccesses_CustomerId",
                       column: x => x.CustomerId,
                       principalTable: "AspNetUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    OrderTotal = table.Column<int>(nullable: false),
                    OrderPlaced = table.Column<DateTime>(nullable: false),
                    OrderPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<string>(maxLength: 450, nullable: false),
                    SettingType = table.Column<int>(nullable: false),
                    Value1 = table.Column<string>(nullable: true),
                    Value2 = table.Column<string>(nullable: true),
                    Value3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingID);
                    table.ForeignKey(
                       name: "FK_Settings_CustomerId",
                       column: x => x.CustomerId,
                       principalTable: "AspNetUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionCustomers",
                columns: table => new
                {
                    SubscriptionCustomerID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<string>(maxLength: 450, nullable: false),
                    SubscriptionStartDate = table.Column<DateTime>(nullable: false),
                    SubscriptionEndDate = table.Column<DateTime>(nullable: false),
                    SubscriptionType = table.Column<int>(nullable: false),
                    ISActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionCustomers", x => x.SubscriptionCustomerID);
                    table.ForeignKey(
                       name: "FK_SubscriptionCustomers_CustomerId",
                       column: x => x.CustomerId,
                       principalTable: "AspNetUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrailBalanceCustomers",
                columns: table => new
                {
                    TrailBalanceCustomerId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailBalanceCustomers", x => x.TrailBalanceCustomerId);
                    table.ForeignKey(
                       name: "FK_TrailBalanceCustomers_CustomerId",
                       column: x => x.CustomerId,
                       principalTable: "AspNetUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallRecordingAgents",
                columns: table => new
                {
                    CallRecordingAgentID = table.Column<Guid>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Duration = table.Column<DateTime>(nullable: false),
                    CallStatus = table.Column<int>(nullable: false),
                    Country = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(maxLength: 450, nullable: false),
                    AgentCustomerID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallRecordingAgents", x => x.CallRecordingAgentID);
                    table.ForeignKey(
                        name: "FK_CallRecordingAgents_AgentCustomers_AgentCustomerID",
                        column: x => x.AgentCustomerID,
                        principalTable: "AgentCustomers",
                        principalColumn: "AgentCustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                       name: "FK_CallRecordingAgents_CustomerId",
                       column: x => x.CustomerId,
                       principalTable: "AspNetUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceAgents",
                columns: table => new
                {
                    DeviceAgentId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    MacAddress = table.Column<string>(nullable: true),
                    IsWorking = table.Column<bool>(nullable: false),
                    DeviceProfileType = table.Column<int>(nullable: false),
                    DeviceId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<string>(maxLength: 450, nullable: false),
                    AgentCustomerID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceAgents", x => x.DeviceAgentId);
                    table.ForeignKey(
                        name: "FK_DeviceAgents_AgentCustomers_AgentCustomerID",
                        column: x => x.AgentCustomerID,
                        principalTable: "AgentCustomers",
                        principalColumn: "AgentCustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                       name: "FK_DeviceAgents_CustomerId",
                       column: x => x.CustomerId,
                       principalTable: "AspNetUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Concerts" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Musicals" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Plays" },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Conferences" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[,]
                {
                    { new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2021, 11, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(4454), 400, new Guid("a441eb40-9636-4ee6-be49-a66c5ec1330b") },
                    { new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2021, 11, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(5433), 135, new Guid("ac3cfaf5-34fd-4e4d-bc04-ad1083ddc340") },
                    { new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2021, 11, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(5491), 85, new Guid("d97a15fc-0d32-41c6-9ddf-62f0735c4c1c") },
                    { new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2021, 11, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(5612), 245, new Guid("4ad901be-f447-46dd-bcf7-dbe401afa203") },
                    { new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2021, 11, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(5645), 142, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") },
                    { new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2021, 11, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(5678), 40, new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923") },
                    { new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2021, 11, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(5705), 116, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "CreatedBy", "CreatedDate", "Date", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), "John Egbert", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 11, 12, 58, 57, 818, DateTimeKind.Local).AddTicks(156), "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg", null, null, "John Egbert Live", 65 },
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), "Michael Johnson", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(2776), "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg", null, null, "The State of Affairs: Michael Live!", 85 },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), "DJ 'The Mike'", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(2915), "DJs from all over the world will compete in this epic battle for eternal fame.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg", null, null, "Clash of the DJs", 85 },
                    { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), "Manuel Santinonisi", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(2950), "Get on the hype of Spanish Guitar concerts with Manuel.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg", null, null, "Spanish guitar hits with Manuel", 25 },
                    { new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), "Nick Sailor", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(3010), "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg", null, null, "To the Moon and Back", 135 },
                    { new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), "Many", new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 11, 12, 58, 57, 819, DateTimeKind.Local).AddTicks(2979), "The best tech conference in the world", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg", null, null, "Techorama 2021", 400 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallRecordingAgents_AgentCustomerID",
                table: "CallRecordingAgents",
                column: "AgentCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceAgents_AgentCustomerID",
                table: "DeviceAgents",
                column: "AgentCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceCustomers");

            migrationBuilder.DropTable(
                name: "CallRecordingAgents");

            migrationBuilder.DropTable(
                name: "DeviceAgents");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "MenuAccesses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SubscriptionCustomers");

            migrationBuilder.DropTable(
                name: "TrailBalanceCustomers");

            migrationBuilder.DropTable(
                name: "AgentCustomers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
