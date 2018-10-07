using Microsoft.ML.Runtime.Api;

namespace Malappo
{
    class BlackFridayData
    {
        // Columns for the data
        [Column("0")]
        public string UserID;

        [Column("1")]
        public string ProductID;

        [Column("2")]
        public string Gender;

        [Column("3")]
        public string Age;

        [Column("4")]
        public string Occupation;

        [Column("5")]
        public string CityCategory;

        [Column("6")]
        public string StayInCurrentCityYears;

        [Column("7")]
        public string MaritalStatus;

        [Column("8")]
        public string ProductCategory1;

        [Column("9")]
        public string ProductCategory2;

        [Column("10")]
        public string ProductCategory3;

        [Column("11")]
        [ColumnName("Purchase")]
        public string Purchase;

    }
}
