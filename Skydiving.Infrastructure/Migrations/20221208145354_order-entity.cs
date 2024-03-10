using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class orderentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemsDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ReceivedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df32f461-27b6-4f15-894e-abc756a892c1", "AQAAAAEAACcQAAAAEBCwP48jTW9/rzEqjNu/C0z09/vXpT4AQrhcFnfuS0ZAHX3WjKai9qJzL5fZHwbbiw==", "d6b3731d-3472-4e96-bf8c-be1ca7b6a5b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff559213-bb59-46b6-b42c-8adaa5fbc07d", "AQAAAAEAACcQAAAAEGweDwfWUUapMcwlX6XpJIxfa6s/WB6duTe8nR0NXU9lfDvByogo2dZF9zMDV/2KyQ==", "06a12888-bf1a-4f31-b7e8-570677efa324" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fa175ab-a643-4112-a7f9-425b6512a54c", "AQAAAAEAACcQAAAAEMBwIW27FPj8ZAUXefqaaanHQiHVHBBKfbFzszNojUvFupBN4vaW04PultlC1RbVSg==", "78999d5a-93f5-4fce-963e-289736fbc7e9" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

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
        }
    }
}
