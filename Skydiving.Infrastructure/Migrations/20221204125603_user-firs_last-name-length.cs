using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class userfirs_lastnamelength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87dad63a-9d84-4012-ac4e-ca99c01c81bf", "AQAAAAEAACcQAAAAEGUC1ZwCx39lyXcJhCY7vacdQB6Bx16f/EeZXkpbJLHelG9QnofFUjwmz9vV7/r1Xw==", "82bec38d-0f72-481c-92ad-860b488a804c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ceeccfe-0fe5-4e1b-adbd-b6a5935c978a", "AQAAAAEAACcQAAAAEItJ5NQWEhtcWoT7s+dvf3zaQfq1WWsi63/u8TGOlk/N/ZhUf1M/CmkJ4jnmu/4g7Q==", "191b5000-e092-47b5-bd78-947b14a57198" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d809d9cc-1548-4d72-80a9-e5b7a2871dba", "AQAAAAEAACcQAAAAEAb2M6jseGOybImpL3RAxH2AErIv58wMIjI/qIwFdBD7d1ZjasupQc9rPpaJFGWn5Q==", "004dd1bf-47b7-4625-99ea-63ebccc7717f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cd35ba0-caa3-4a44-a6b5-b52a1a4d56cf", "AQAAAAEAACcQAAAAEEc9YGTTjRy/89dIRMOGxViGigpur8F7ocdB8q1PpDAnmUpYuDioh4efGBIF5TIxNQ==", "67560df8-dc07-4027-84bc-b2066d38a5c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcc14432-af75-4660-b7a1-cd4bfc12e3a7", "AQAAAAEAACcQAAAAEDq28nrcfP0u72JJlXBt8ZLPdfHMVdunfWXdTfiLayzHpdmnwr83bNXKdckqBwCTag==", "b9a5ad68-d8be-4129-bcf6-48e63f4a5753" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f847847-320d-4b61-b206-18cb23cbac2d", "AQAAAAEAACcQAAAAED2AWZ7qebUF3TkKBcfaIUwWI2KrvqYnRCGyLmDvvPiWW4fViJZD0XSVoBsVzN1ivQ==", "5e6ac45d-d39f-412c-ba46-1981a258b21b" });
        }
    }
}
