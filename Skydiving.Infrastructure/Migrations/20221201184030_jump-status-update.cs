using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class jumpstatusupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd887ad2-59f6-457c-bee1-6610be02628a", "AQAAAAEAACcQAAAAEAf6in29rvqI0p+rDnG0NeQwyavtf1NMrujpgoSj0hwttQiW7/esYRDmM2raU7jl3g==", "d5f19dd0-b1ed-482b-a1d9-a668b58aa940" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0a4f9e4-0907-4111-8d0b-2e762a2092ee", "AQAAAAEAACcQAAAAEPJxbcQTvbQY/KGjdBQpvDc/Vx8bQ1Jyw34pG0FuqZpLRtelo1oc/67DSyMtY33JOw==", "5f9c8941-a04a-496f-b8f8-0a6b99f4f878" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f75e9712-fadd-4950-a38c-7b63da5c6489", "AQAAAAEAACcQAAAAEENVgcAddD5mjwaaOq9mHgigrvUzbfFO0gnP2+UgVw6RsCn1ZL8J5i1AQVQmk3wwAQ==", "99461bc9-615d-4bd1-bdfa-e3dcb5ab2690" });

            migrationBuilder.InsertData(
                table: "JumpStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Deleted" },
                    { 5, "Completed" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JumpStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JumpStatus",
                keyColumn: "Id",
                keyValue: 5);

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
    }
}
