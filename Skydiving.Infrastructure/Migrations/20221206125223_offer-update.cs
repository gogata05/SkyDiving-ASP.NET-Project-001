using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class offerupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Offers_OwnerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OwnerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59fbb65a-7400-482d-ad50-9e1ff3897dd4", "AQAAAAEAACcQAAAAEPipN9hcurRnzGSOQ5AUYEsNnnUo0vWFmxPazY4ruua8IPJ4b55V2yR1jrGJzwFVkA==", "7c403c0d-49c6-4477-9e9e-d2abcd2fe3b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d0e4666-2636-4fdf-9569-b3f92ec5af28", "AQAAAAEAACcQAAAAEBAKVz5dzElI1ZL0mz7xtkvXW69e9O1S3vPW+YiV6konfFFocfqctev6I2ldG/XHaA==", "4f77b1a5-64e6-4d9b-a632-72c1e9c5fb33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "504fbefa-3678-4290-ac59-623b914c5d80", "AQAAAAEAACcQAAAAEN0mXFZp1I7Of6fbd3g6j8Ji/ZYa5h/5dGQfp4tIdEmKx/cj4pVo2jdeopqtrUp1hw==", "24866c91-c161-46f9-a04b-8abe07637682" });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OwnerId",
                table: "Offers",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_OwnerId",
                table: "Offers",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_OwnerId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_OwnerId",
                table: "Offers");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OwnerId",
                table: "AspNetUsers",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Offers_OwnerId",
                table: "AspNetUsers",
                column: "OwnerId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
