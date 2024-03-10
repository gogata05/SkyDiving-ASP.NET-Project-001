using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class removeRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "UPT PD Sigma Tandem Main Canopy. This canopy, made by Performance Designs exclusively for United Parachute Technologies, is the preferred choice for use with Sigma and Micro Sigma Tandem Containers.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "a1a7845f-2c3a-4bd9-addd-94846181d595", "AQAAAAEAACcQAAAAENLIdTLriGLtNUe5mvweSqHHq4vPVcBMKc1ssey2nrQPZTqg+gJpgbuarKea3qy1wA==", "e963ff96-7395-4e28-971c-c46f736e3702" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsInstructor", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "74133a53-fceb-4ad7-8e88-e594fcf50e04", "jumper@mail.com", false, null, false, null, false, null, "JUMPER@MAIL.COM", "JUMPER", "AQAAAAEAACcQAAAAEI+M1NFA9e9jfMMnnOk20qNjlmEC3hhngOp6XYZ2s7caXyFBvZqq/4QCI9PNMm0cYg==", null, false, "8fa709d9-b82f-4d07-ba38-49f8afd10e29", false, "jumper" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "4c7b2266-b432-4718-bb70-eb88651bcfd0", "instructor@mail.com", false, null, false, null, false, null, "INSTRUCTOR@MAIL.COM", "INSTRUCTOR", "AQAAAAEAACcQAAAAEMp4Xxn6p4cUD5PtjNbuRQavOQN37NSuJ2hbzdO7SwxAZFwwB2P+aYUKfDA3CIYkeQ==", null, false, "26fba492-97de-4a9a-b18f-47a7d63ef470", false, "instructor" }
                });

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "PD Sigma Tandem Main Canopy. This canopy, made by Performance Designs exclusively for United Parachute Technologies, is the preferred choice for use with Sigma and Micro Sigma Tandem Containers.");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5d937746-9833-4886-83d1-3c125ad5294c", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c8a8cf93-46b1-4e79-871a-1f4742a0db83", "dea12856-c198-4129-b3f3-b893d8395082" });
        }
    }
}
