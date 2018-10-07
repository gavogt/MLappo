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
        public int Occupation;

        [Column("5")]
        public string CityCategory;

        [Column("6")]
        public string StayInCurrentCityYears;

        [Column("7")]
        public int MaritalStatus;

        [Column("8")]
        public int ProductCategory1;

        [Column("9")]
        public int ProductCategory2;

        [Column("10")]
        public int ProductCategory3;

        [Column("11")]
        public int Purchase;

    }
}
