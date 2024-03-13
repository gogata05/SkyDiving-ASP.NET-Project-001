using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class messageentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e9920d6-f49d-419a-b9b8-5f984868930f", "AQAAAAEAACcQAAAAENq6/3UKiyrAMxjXauC+wr8AmdxTCi3mQB9KaJv6LTSvx84pnl2Ykg0aoQCwCLG6Kw==", "c373469f-943a-47fd-abd9-e998677b3efb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d298b8ea-f96a-4dd5-8a03-2c184ed33edb", "AQAAAAEAACcQAAAAEAq5JMpXo54kzj5/o8RWpj5WACDkZTKieQLtDCMt2m0lpIdaApvLVErJJLbaIGjaow==", "5f5a5bcb-0864-488d-a100-ee9078ec1475" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b45b6e31-cafd-43b2-95a3-454703e36780", "AQAAAAEAACcQAAAAEJ/tCwgWuDVPPmww0ft7ctvxidjAhb3Zi/Fu/0WRrBbXydrkaV3t2T/TtNmLPd/s+w==", "ea5af470-0b2e-4e9b-9e2c-175a7591eb0e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a890ca82-75f3-4f2a-bd16-56a113e35af6", "AQAAAAEAACcQAAAAEFRYSjbzVPcihRmLwWYM31HM3fEdcguOha2CmcxDeRTb4sGlpRWrrFD80472dVYEPg==", "8f12cb40-36b1-4329-88a4-5b337213cc84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b77b72fc-1563-4884-a888-54e8a0fb1ad4", "AQAAAAEAACcQAAAAEMAwRoTIXv0gmVFRJMl+vyRQ0UCx8woMZtj5+flQDA3rgtM9v+jc1vXJu+n+zvP2Jg==", "cd6b60bc-1e43-4288-9283-7647ed132708" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eae24bb2-b1b0-487d-a897-b24ace483dbb", "AQAAAAEAACcQAAAAEIkmDPUXZACGDRmo7OFFpcfHDDlvZJHN2TBFmWGStfugZWgrw6FnVyv5XRkgCC0OCw==", "e0a2a457-c4e1-493f-94e1-a6be270e8b81" });
        }
    }
}
