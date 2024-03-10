using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class imgUrlNotNullStringLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Equipments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4024c5da-8681-4dc5-8e6a-d4bde67795ec", "AQAAAAEAACcQAAAAEE7DiAuxuYHKnBNOX/6hs7G4qdqtbTHmbgPvapQz/y+UBL4c1M5xY+S2MTcmsDgUvQ==", "7366c132-5028-41c2-826c-57b3701895c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cb016eb-ef01-4afd-a49f-42f1173eeb55", "AQAAAAEAACcQAAAAEJqVysSLewgEJzU85cMPKoc4dkDM5Zsa+A/s6GulhlpTFwnNzdeFukZhO3C6ScqIhA==", "76aa0913-dd90-47a2-a927-acf490e36ec1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82733b62-12b2-44ff-85dd-2cff9263c6ee", "AQAAAAEAACcQAAAAEF77v71f/9cfasGdjF4UcM6FJIyR07uPV9LXNfar1FSLqaxPKueDf54rMp/L/tNaaw==", "3c4ede70-4ad0-43ff-aef6-63cd32d34d74" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

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
    }
}
