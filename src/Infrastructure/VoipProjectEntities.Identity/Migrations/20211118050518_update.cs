using Microsoft.EntityFrameworkCore.Migrations;

namespace VoipProjectEntities.Identity.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3538ce4-d7c3-4fca-af63-59f15a826db0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7a0d7fd-f132-4723-b40e-5c3bbe4e8d9a");

            migrationBuilder.AddColumn<string>(
                name: "OrganisationName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleInBusiness",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ae7db51-52f4-4330-82b7-5d36c58f39a6", "ed997c9d-aaa3-4824-b786-33506a36b253", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "829cf365-db3b-4e1b-a07e-c840261b1a5c", "6d342254-a01f-4f2b-8dd1-844cb65c2efa", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ae7db51-52f4-4330-82b7-5d36c58f39a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "829cf365-db3b-4e1b-a07e-c840261b1a5c");

            migrationBuilder.DropColumn(
                name: "OrganisationName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleInBusiness",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3538ce4-d7c3-4fca-af63-59f15a826db0", "6ae31e71-8367-4470-9f58-c5098a14a01d", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7a0d7fd-f132-4723-b40e-5c3bbe4e8d9a", "0ddd6166-54ab-4027-ba41-7c6b456b3ab7", "Administrator", "ADMINISTRATOR" });
        }
    }
}
