using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class jumpoffermodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8f13fac-5de8-4ea5-9a05-ec176c2902fc", "AQAAAAEAACcQAAAAEAsMxZMV+8qVcYkzALUpmCtv2c0IBcpHbKwv73oQopAMXFnviZWjflq6DfezppOJWw==", "351f9cb2-f197-4398-9694-d3a5ca902278" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84ba6314-5cb6-4956-a597-29573a346814", "AQAAAAEAACcQAAAAEHVXtdfkWsvm++j0gnN4S6okyrNOBp269An0uY2i2LisonniRpIvtf0iik+sMEu/nw==", "bd69e462-d36f-4f2e-b541-d9c98edecc8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc0bfb2b-67cc-404c-be6c-9183b3312da5", "AQAAAAEAACcQAAAAEJwdoHOodSQdkC1XbcXr6C2dmkhUj6fMT7b3A+qka5YXiSe15WLBLBT65A0q0B49vQ==", "ec364b9e-b763-4b44-a220-250eaeab928c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
