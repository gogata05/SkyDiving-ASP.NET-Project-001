namespace Skydiving.Infrastructure.Data.DataConstants
{
    public static class EntityConstants
    {
        public class Equipment
        {
            //Title
            public const int EquipmentTitleMaxLength = 50;

            //Brand
            public const int EquipmentBrandMaxLength = 50;

            //Quantity
            public const int EquipmentQuantityMinLength = 1;
            public const int EquipmentQuantityMaxLength = 1000;

            //Description
            public const int EquipmentDescriptionMaxLength = 500;

            //Price
            public const int EquipmentPriceMinLength = 2;
            public const int EquipmentPriceMaxLength = 18;

            //ImageUrl
            public const int EquipmentImageUrlMaxLength = 500;
        }

        public class EquipmentCategory
        {
            //Name
            public const int EquipmentCategoryNameMaxLength = 50;
        }

        public class Jump
        {
            //Title
            public const int JumpTitleMaxLength = 50;

            //Description
            public const int JumpDescriptionMaxLength = 500;

            //OwnerName
            public const int JumpOwnerNameMaxLength = 50;
        }
        public class JumpCategory
        {
            //Name
            public const int JumpCategoryNameMaxLength = 50;
        }

        public class Offer
        {
            //Description
            public const int OfferDescriptionMaxLength = 500;

            //Price
            public const int OfferPriceMinLength = 2;
            public const int OfferPriceMaxLength = 18;
        }

        public class Order
        {
            //TotalCost
            public const int OrderTotalCostMinLength = 2;
            public const int OrderTotalCostMaxLength = 18;
        }

        public class Rating
        {
            //Comment
            public const int RatingCommentMaxLength = 200;

            //Points
            public const int RatingPointsMinLength = 1;
            public const int RatingPointsMaxLength = 5;
        }

        public class User
        {
            //FirstName
            public const int UserFirstNameMaxLength = 50;

            //LastName
            public const int UserLastNameMaxLength = 50;
        }
    }
}
