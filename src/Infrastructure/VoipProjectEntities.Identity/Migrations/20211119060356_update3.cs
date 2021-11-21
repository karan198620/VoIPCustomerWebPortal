using Microsoft.EntityFrameworkCore.Migrations;

namespace VoipProjectEntities.Identity.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "211faebf-f0f0-40de-8077-210f50d532e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d048c393-fc16-4068-bc1f-cbf2b50a9247");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb750f65-8827-46cd-a7c6-4096afffbdec", "e1479b5c-95cd-4a1a-8117-7ca9a176cb33", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02b8244b-8198-4b5b-a263-0de6d5f1352d", "cb28fdbd-b435-4a61-b669-adfc2b67e5e2", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02b8244b-8198-4b5b-a263-0de6d5f1352d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb750f65-8827-46cd-a7c6-4096afffbdec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d048c393-fc16-4068-bc1f-cbf2b50a9247", "e80ef656-fbb6-427d-8ef7-804198c1a760", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "211faebf-f0f0-40de-8077-210f50d532e5", "2e339ac6-f28f-4653-94fd-1b96bbcc2277", "Administrator", "ADMINISTRATOR" });
        }
    }
}
