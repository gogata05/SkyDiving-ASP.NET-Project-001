using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class commentnotrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Ratings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Ratings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

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
    }
}
