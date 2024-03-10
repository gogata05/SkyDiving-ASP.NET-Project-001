using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skydiving.Infrastructure.Data.EntityModels;

namespace Skydiving.Infrastructure.Data.Configuration
{
    internal class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Equipment> CreateCategories()
        {
            List<Equipment> equipments = new List<Equipment>()
            {
                new Equipment()
                {
                    Id = 1,
                    Title = "J2 Freefly Suit",
                    Brand = "J2",
                    Quantity = 20,
                    EquipmentCategoryId = 3,
                    Description = "The J2 Free Fly Suit, with its innovative design, offers three fit options: tight, loose, or standard, tailored for any skydiver's preference. Created by three unique designers, it provides varied styles for personal expression. Its articulated design promotes free movement, ideal for skydiving's demands. Made from durable nylon, it balances strength and flexibility for optimal performance in the air.",
                    OwnerId = "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                    IsActive = true,
                    Price = 250.00m,
                    ImageUrl = "https://jediairwear.co.uk/wp-content/uploads/2024/01/cl-640x960.jpg"
                },

                new Equipment()
                {
                    Id = 2,
                    Title = "PEEKSTEEP SKYDIVING GOGGLES",
                    Brand = "PEEKSTEEP",
                    Quantity = 38,
                    EquipmentCategoryId = 2,
                    Description = "Peeksteep Skydiving Goggles take your style to the skies! Peeksteep Skydiving Goggles are a high-quality pair of skydiving goggles that also come in a variety of strap and lens colors to match your skydiving gear. Features:Large adjustable straps in a variety of colors, Anti-fog & Anti-scratch lens coating, Fits any face shape or size, Thick polycarbonate lens, UV 400 protection, Comfortable & lightweight, Ventilated lens to prevent fogging.",
                    OwnerId = "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                    IsActive = true,
                    Price = 20.00m,
                    ImageUrl = "https://sky-shop.eu/image/cache/catalog/Peeksteep/Goggles/peeksteep_other_01-800x800w.jpg"
                },

                new Equipment()
                {
                    Id = 3,
                    Title = "ULTIMATE L&B ARES2 SKYDIVING GLOVES",
                    Brand = "AKANDO",
                    Quantity = 15,
                    EquipmentCategoryId = 7,
                    Description = "Akando Ultimate gloves feature an L&B Ares2 pocket for improved altitude awareness. Designed for skydivers, they offer superior grip and durability, thanks to over a decade of feedback and testing. Highlights include a tackified leather palm, reinforced fingers, Kevlar stitching, a breathable back, a secure YKK velcro wrist closure, and a professional appearance.",
                    OwnerId = "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                    IsActive = true,
                    Price = 36.00m,
                    ImageUrl = "https://sky-shop.eu/image/cache/catalog/Akando/Ultimate/Akando-ultimate-lb-ares2-gloves_2-800x800.jpeg"
                },

                new Equipment()
                {
                    Id = 4,
                    Title = "SIGMA TANDEM MAIN CANOPY PARACHUTE",
                    Brand = "UPT",
                    Quantity = 30,
                    EquipmentCategoryId = 6,
                    Description = "UPT PD Sigma Tandem Main Canopy. This canopy, made by Performance Designs exclusively for United Parachute Technologies, is the preferred choice for use with Sigma and Micro Sigma Tandem Containers.",
                    OwnerId = "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                    IsActive = true,
                    Price = 3789.00m,
                    ImageUrl = "https://as2.ftcdn.net/v2/jpg/01/63/30/01/1000_F_163300195_NHBtdr1pmdOR2WhQ3TJKVn352L55IQPV.jpg"
                },

                new Equipment()
                {
                    Id = 5,
                    Title = "AERONAUT ANALOG SKYDIVING ALTIMETER",
                    Brand = "PARASPORT",
                    Quantity = 37,
                    EquipmentCategoryId = 5,
                    Description = "Parasport's mechanical altimeter, the Aeronaut, retains its robust, cost-effective, and precise mechanism but is now redesigned. It's calibrated for up to 6,000 m (19,000 ft), featuring a temperature-adjusted aneroid capsule for consistent accuracy. The updated aluminum case, at 55 mm in diameter and 21 mm thick, is compact, with durable, water-resistant glass. It includes easily replaceable mounts with steel brackets, offering versatile orientation for either hand or wrist mounting.",
                    OwnerId = "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                    IsActive = true,
                    Price = 209.99m,
                    ImageUrl = "https://sky-shop.eu/image/cache/Parasport/Aeronaut_Tri-800x800.jpg"
                },

                new Equipment()
                {
                    Id = 6,
                    Title = "ICON STUDENT CONTAINER",
                    Brand = "AERODYNE",
                    Quantity = 12,
                    EquipmentCategoryId = 4,
                    Description = "The ICON Student is designed for DZ operators, instructors, and students, addressing the growing diversity and needs of student training. It offers a versatile harness and container system for Static line, IAD, AFF, or Solo freefall, meeting DZ requirements. Student jumpers value safety and comfort. The Student ICON ensures reliability, durability, and comfort, making first jumps safer and enjoyable.",
                    OwnerId = "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                    IsActive = true,
                    Price = 1669.99m,
                    ImageUrl = "https://sky-shop.eu/image/cache/may18/icon-student-container-800x800.jpg"
                },

                new Equipment()
                {
                    Id = 7,
                    Title = "COOKIE G35 SKYDIVING HELMET",
                    Brand = "COOKIE COMPOSITES",
                    Quantity = 10,
                    EquipmentCategoryId = 1,
                    Description = "The Cookie G35 Skydiving Helmet improves the G3 with better comfort, customization, and design. It has a traditional shape with a lower back for improved security and ease. The chin is padded for comfort, plus there's more ear space and altimeter pockets. Its visor and new side plates cut noise, and it's ready for FlySight installation. The G35 allows for wide customization with multiple colors for side, top plates, and visors.",
                    OwnerId = "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                    IsActive = true,
                    Price = 509.99m,
                    ImageUrl = "https://sky-shop.eu/image/cache/catalog/Cookie/G35/Cookie_G35_Skydiving_Helmet_Black-800x800.png"
                }

             };

            return equipments;
        }
    }
}
