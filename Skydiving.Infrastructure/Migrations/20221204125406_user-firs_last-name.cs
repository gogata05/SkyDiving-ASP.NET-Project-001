using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skydiving.Infrastructure.Migrations
{
    public partial class userfirs_lastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cd35ba0-caa3-4a44-a6b5-b52a1a4d56cf", "AQAAAAEAACcQAAAAEEc9YGTTjRy/89dIRMOGxViGigpur8F7ocdB8q1PpDAnmUpYuDioh4efGBIF5TIxNQ==", "67560df8-dc07-4027-84bc-b2066d38a5c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcc14432-af75-4660-b7a1-cd4bfc12e3a7", "AQAAAAEAACcQAAAAEDq28nrcfP0u72JJlXBt8ZLPdfHMVdunfWXdTfiLayzHpdmnwr83bNXKdckqBwCTag==", "b9a5ad68-d8be-4129-bcf6-48e63f4a5753" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f847847-320d-4b61-b206-18cb23cbac2d", "AQAAAAEAACcQAAAAED2AWZ7qebUF3TkKBcfaIUwWI2KrvqYnRCGyLmDvvPiWW4fViJZD0XSVoBsVzN1ivQ==", "5e6ac45d-d39f-412c-ba46-1981a258b21b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

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
        }
    }
}
