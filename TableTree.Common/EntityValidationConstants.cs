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
    }
}
