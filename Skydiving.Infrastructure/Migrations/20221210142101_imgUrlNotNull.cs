using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class imgUrlNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c030055d-0046-4040-85a2-616297737fd2", "AQAAAAEAACcQAAAAEKidNLdVaA8K6vFKK4YCBDjs5nwsiDxm+65wnwVd00hWW7jtWzV48rudFHg2DKVMUw==", "1900172e-945e-4af2-bda7-1637f258a32a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68a52f2e-366f-40f4-aaa9-925f53a8b850", "AQAAAAEAACcQAAAAEL9st+bOQ0D2gD3rE3eFiSpG8+1rLPfbT5sjVhTgYHTMxi226pNQbJQ3OlrC8ni9ZA==", "28130bd8-175e-470e-bd5b-f509bd3b9010" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c64eba16-b337-42b3-aa3d-760bb974d2b4", "AQAAAAEAACcQAAAAEMBw7lmidaST0qd9Kby98vcaZayA07VF+nNMq5EWjjbkUBUMbUMSs4y73LQ2KouQ0A==", "a44c1f70-0203-4ef2-9a42-8ddfc5ebb725" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61989f56-607e-4aae-8eed-f06c8c1ade9a", "AQAAAAEAACcQAAAAEEiFgXnGCgm1N8NK+2k5qqcWWNAXz+Ee5o6WodwtAzS+RbIhUlYQURiFlkQTOlBCyg==", "1f889772-768f-4e9c-9318-1edfdf772c29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbbcaeb1-512a-4f8b-8547-1bfcf1320093", "AQAAAAEAACcQAAAAEI0jk3sX7Ymhd6a/Ha2WHpW/TgGHzJSbz5iswA9IiIb9rJ9wa+tcKe3qrmjbiisBCg==", "287e722e-c6e7-4f61-aeec-56c324d2b8b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9179dc1e-8507-4ed3-8bff-304ae8f5359a", "AQAAAAEAACcQAAAAEIVnVz9XUCxOUl/LQFENK9ZebxML+rb6xMLbGUrCABvbXqXMaxJQoogITh1G/eHHeQ==", "904598f0-caa6-4ade-8534-8c3c8ba62cef" });
        }
    }
}
