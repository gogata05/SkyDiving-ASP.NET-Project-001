using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class equipmentimageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Equipments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4435efde-8d86-44e1-a7ed-17801155141b", "AQAAAAEAACcQAAAAEA8KC4OVOBYYZi9Eq9d44GbJblJcZJO+aHXifSztCZakZ6ZgXYdeWCuT2n+uKBFv/A==", "276334f9-40ff-476b-bc92-5f812e460a09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5733235c-9343-4483-9943-eb3a3f127eff", "AQAAAAEAACcQAAAAEEVfrP0BtTdkZpbfwnzOiDS/ZMAPiSRvm6RhbSIGiJEQZuc/snjjVc2eCY83U1aNiw==", "487c5180-d066-47c6-be3d-69c0fbef6ef1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c991dcd-f785-448b-82ca-197b7962ecbd", "AQAAAAEAACcQAAAAEChqgK9Pu7vJRtVTduq7LVLaOGdNohjlkS+YOFGbOWC5pII3D1ONWh4eALEf/baAbA==", "f384e801-03c1-4e86-8db5-dfe4470529b8" });
        }
    }
}
