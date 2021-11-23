using Microsoft.EntityFrameworkCore.Migrations;

namespace VoipProjectEntities.Identity.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "RoleInBusiness",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d048c393-fc16-4068-bc1f-cbf2b50a9247", "e80ef656-fbb6-427d-8ef7-804198c1a760", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "211faebf-f0f0-40de-8077-210f50d532e5", "2e339ac6-f28f-4653-94fd-1b96bbcc2277", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "211faebf-f0f0-40de-8077-210f50d532e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d048c393-fc16-4068-bc1f-cbf2b50a9247");

            migrationBuilder.AddColumn<string>(
                name: "RoleInBusiness",
                table: "AspNetUsers",
                type: "nvarchar(max)",
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
    }
}
