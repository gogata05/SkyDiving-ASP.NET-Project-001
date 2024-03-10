using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class precisionfordecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b10ca31e-e1c3-4959-a7b7-66b585ff9e26", "AQAAAAEAACcQAAAAENrXCTBqSxzy1urL7K5bwkr911SQL0ART6wM1fspW57wUgPPVV+S+Hu1GfXd+gSgmA==", "b3f46a3a-b4c7-4a79-bf5f-c48d394f0943" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad43a51b-32b6-41ec-ac51-2653e33fc882", "AQAAAAEAACcQAAAAEGuIsH2WM3+vCmJBdmtwRbUgz/OoWN4HgTQJ+ttZkmtRVd6DYWrXwR751cKQqGVyAw==", "cd5a6c8c-1d12-47ed-b540-7bec3332e8af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f330a5f-efe4-4a68-8e79-33435c6b3815", "AQAAAAEAACcQAAAAELX8EuReeengA47jF7E13NHcw7BeegPzAkFejUUZDRiPF0eTsUoMoAFQDRVfldau6Q==", "8bdd0464-6c6b-4d98-a524-e812bb15c73a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Orders");

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
        }
    }
}
