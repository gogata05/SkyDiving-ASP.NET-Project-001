using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class addRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d937746-9833-4886-83d1-3c125ad5294c", "80196750-3beb-42a1-b321-0aa9c9f41275", "Jumper", "JUMPER" },
                    { "c8a8cf93-46b1-4e79-871a-1f4742a0db83", "292f8d0e-c368-4cf1-bb0a-b8cda6096ea9", "Instructor", "INSTRUCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1e62f853-4a41-4652-b9a9-8e8b236e24c7", "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26cba651-012e-471b-aad8-a2020437ebd0", "AQAAAAEAACcQAAAAEKWB01BTMbDQRY7Atd/vKAXEHJ+EC9ig8MhTPH9EqIcg9vH0SdMHf1+Usej8kwD3Zw==", "ca1abc4d-5a38-4f1c-b550-dc1dad97873a" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsInstructor", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "ac188ae5-f4ab-4f18-acff-686c4ce40c92", "jumper@mail.com", false, null, false, null, false, null, "JUMPER@MAIL.COM", "JUMPER", "AQAAAAEAACcQAAAAED//ysOcIB6wJsMbOlG+TIuOrj/Ncxp/vgf2IR6V3T2EmQzntitzS3pbg4NvAAKevw==", null, false, "3065d476-666b-4605-8c51-d148a1573b39", false, "jumper" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "53e4fa6b-3f1f-4dd8-aa67-029272ddfc74", "instructor@mail.com", false, null, false, null, false, null, "INSTRUCTOR@MAIL.COM", "INSTRUCTOR", "AQAAAAEAACcQAAAAEOCJ0gjbYtEFCRdsYJOMoqfBGMPmxNUFZdJ9PF2+HMXqRLfsf5Ps0hf/waIvETVsPA==", null, false, "8d3678e0-34f9-4bc4-9385-0b58e60f045a", false, "instructor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5d937746-9833-4886-83d1-3c125ad5294c", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c8a8cf93-46b1-4e79-871a-1f4742a0db83", "dea12856-c198-4129-b3f3-b893d8395082" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5d937746-9833-4886-83d1-3c125ad5294c", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e62f853-4a41-4652-b9a9-8e8b236e24c7", "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c8a8cf93-46b1-4e79-871a-1f4742a0db83", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d937746-9833-4886-83d1-3c125ad5294c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8a8cf93-46b1-4e79-871a-1f4742a0db83");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b482d5a-50d4-4b03-b72c-52b9604db117", "AQAAAAEAACcQAAAAEG15Yqto2yVPXE7enOiuiTXTY8wW9WoOt4T8Wj9Uy/CTjzgpm5Ru7W5DQ6bv5UDAiw==", "146ddae1-e88d-4f3b-92e3-22eb4ab9a8a8" });
        }
    }
}
