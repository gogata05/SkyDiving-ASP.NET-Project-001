using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace Skydiving.Infrastructure.Migrations
{
    public partial class equipmentconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsActive", "OwnerId", "Price", "Quantity", "Title", "EquipmentCategoryId" },
                values: new object[,]
                {
                    { 1, "J2", "The J2 Free Fly Suit, with its innovative design, offers three fit options: tight, loose, or standard, tailored for any skydiver's preference. Created by three unique designers, it provides varied styles for personal expression. Its articulated design promotes free movement, ideal for skydiving's demands. Made from durable nylon, it balances strength and flexibility for optimal performance in the air.", "https://jediairwear.co.uk/wp-content/uploads/2024/01/cl-640x960.jpg", true, "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e", 250.00m, 20, "J2 Freefly Suit", 3 },
                    { 2, "PEEKSTEEP", "Peeksteep Skydiving Goggles take your style to the skies! Peeksteep Skydiving Goggles are a high-quality pair of skydiving goggles that also come in a variety of strap and lens colors to match your skydiving gear. Features:Large adjustable straps in a variety of colors, Anti-fog & Anti-scratch lens coating, Fits any face shape or size, Thick polycarbonate lens, UV 400 protection, Comfortable & lightweight, Ventilated lens to prevent fogging.", "https://sky-shop.eu/image/cache/catalog/Peeksteep/Goggles/peeksteep_other_01-800x800w.jpg", true, "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e", 239.99m, 33, "PEEKSTEEP SKYDIVING GOGGLES", 2 },
                    { 3, "AKANDO", "Basic equipment kit for everyday household repairs. Includes screwdrivers, long nose pliers, diagonal/ side cutters, adjustable wrench, folding hex keys, tape measure, junior hacksaw, half-round file, claw hammer and magnetic torpedo level. Supplied in a Magnusson soft storage bag.", "https://sky-shop.eu/image/cache/catalog/Akando/Ultimate/Akando-ultimate-lb-ares2-gloves_2-800x800.jpeg", true, "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e", 36.00m, 15, "ULTIMATE L&B ARES2 SKYDIVING GLOVES", 7 },
                    { 4, "UPT", "PD Sigma Tandem Main Canopy. This canopy, made by Performance Designs exclusively for United Parachute Technologies, is the preferred choice for use with Sigma and Micro Sigma Tandem Containers.", "https://as2.ftcdn.net/v2/jpg/01/63/30/01/1000_F_163300195_NHBtdr1pmdOR2WhQ3TJKVn352L55IQPV.jpg", true, "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e", 3789.00m, 30, "SIGMA TANDEM MAIN CANOPY PARACHUTE", 6 },
                    { 5, "PARASPORT", "Parasport's mechanical altimeter, the Aeronaut, retains its robust, cost-effective, and precise mechanism but is now redesigned. It's calibrated for up to 6,000 m (19,000 ft), featuring a temperature-adjusted aneroid capsule for consistent accuracy. The updated aluminum case, at 55 mm in diameter and 21 mm thick, is compact, with durable, water-resistant glass. It includes easily replaceable mounts with steel brackets, offering versatile orientation for either hand or wrist mounting.", "https://sky-shop.eu/image/cache/Parasport/Aeronaut_Tri-800x800.jpg", true, "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e", 209.99m, 37, "AERONAUT ANALOG SKYDIVING ALTIMETER", 5 },
                    { 6, "AERODYNE", "The ICON Student is designed for DZ operators, instructors, and students, addressing the growing diversity and needs of student training. It offers a versatile harness and container system for Static line, IAD, AFF, or Solo freefall, meeting DZ requirements. Student jumpers value safety and comfort. The Student ICON ensures reliability, durability, and comfort, making first jumps safer and enjoyable.", "https://sky-shop.eu/image/cache/may18/icon-student-container-800x800.jpg", true, "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e", 1669.99m, 12, "ICON STUDENT CONTAINER", 4 },
                    {  7, "COOKIE COMPOSITES", "The Cookie G35 Skydiving Helmet improves the G3 with better comfort, customization, and design. It has a traditional shape with a lower back for improved security and ease. The chin is padded for comfort, plus there's more ear space and altimeter pockets. Its visor and new side plates cut noise, and it's ready for FlySight installation. The G35 allows for wide customization with multiple colors for side, top plates, and visors.", "https://sky-shop.eu/image/cache/catalog/Cookie/G35/Cookie_G35_Skydiving_Helmet_Black-800x800.png", true, "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e", 509.99m, 10, "COOKIE G35 SKYDIVING HELMET", 1
                    }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 7);

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
    }
}
