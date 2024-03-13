using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class messageentity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74133a53-fceb-4ad7-8e88-e594fcf50e04", "AQAAAAEAACcQAAAAEI+M1NFA9e9jfMMnnOk20qNjlmEC3hhngOp6XYZ2s7caXyFBvZqq/4QCI9PNMm0cYg==", "8fa709d9-b82f-4d07-ba38-49f8afd10e29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1a7845f-2c3a-4bd9-addd-94846181d595", "AQAAAAEAACcQAAAAENLIdTLriGLtNUe5mvweSqHHq4vPVcBMKc1ssey2nrQPZTqg+gJpgbuarKea3qy1wA==", "e963ff96-7395-4e28-971c-c46f736e3702" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c7b2266-b432-4718-bb70-eb88651bcfd0", "AQAAAAEAACcQAAAAEMp4Xxn6p4cUD5PtjNbuRQavOQN37NSuJ2hbzdO7SwxAZFwwB2P+aYUKfDA3CIYkeQ==", "26fba492-97de-4a9a-b18f-47a7d63ef470" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Messages");

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
    }
}
