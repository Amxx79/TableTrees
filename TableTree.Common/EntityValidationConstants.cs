namespace TableTree.Common
{
    public static class EntityValidationContants
    {
        public static class Product
        {
            public const int NameMaxLength = 60;
            public const int NameMinLength = 3;

            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 5;
        }

        public static class Category
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 3;
        }

        public static class TreeType
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 3;
        }

        public static class Order
        {
            public const int FistNameMinLength = 0;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 0;
            public const int LastNameMaxLength = 50;

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;

            public const int ShippingCityMinLength = 5;
            public const int ShippingCityMaxLength = 30;

            public const int ShippingAddressMinLength = 1;
            public const int ShippingAddressMaxLength = 100;
        }
    }
}
