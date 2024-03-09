using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class ratingentityupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Ratings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JumpId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "160897b9-a642-4680-a632-b098783914fd", "AQAAAAEAACcQAAAAELUs7NctR81fXeQmKr0ok6rosHQKrpmft0YBoaQdIlyJUorDMvi+qGkePnghu0/1Rg==", "53565725-8576-421f-b043-f313dc730839" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e06a52e0-731c-48d5-be9b-2542c27f5f58", "AQAAAAEAACcQAAAAEEUnScOcav21GfJK3O/30lnqpjWhnVl6D2AFHeAwV9esG7O0imom2IKzs9OBdfZ53A==", "2413376c-6302-4d88-a78e-31e90769ebb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b05072b6-1be3-4193-ac7c-597df3db0ec7", "AQAAAAEAACcQAAAAEHKi6WIZv9MlKMGZbn5klu+QF1WNphOfZnHJo8rmVLovjC0yIvG0gf+TlvwcDUQbig==", "dea3d890-f1a5-4cde-9955-27d87778dd7f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "JumpId",
                table: "Ratings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31fe2dbc-8520-4c5a-b439-4b51b52cc293", "AQAAAAEAACcQAAAAEJuaffcI9kuz8BY1oQmUZmupKAUM2LNqeqWUUz+lsk7Mw42AvwLM2z0X8k2bqJGgFQ==", "82627307-9b1a-4be9-92b1-9b1d0aef3836" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae16c51f-adb7-4837-9230-3ca37f732cad", "AQAAAAEAACcQAAAAEBDIL+1juTpEFNZ1HmvaXMchMYGNd6Mwz6PysgD8jJdqrSd9MlNVgVtDl4qDU/H8Eg==", "c49cfec9-ed5d-45b5-9a1c-eb0583ec8273" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "215da397-d43e-48a6-9bd9-144a6c572a0b", "AQAAAAEAACcQAAAAELiZBb+74RpuasyzWYeAzDyWkypWbODAIwejEqua4z8vrjjQcFnKnvEzQlZbLbjIWA==", "f9da015e-55b0-4f17-b01d-fac1acdc2ebf" });
        }
    }
}
