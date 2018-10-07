using Microsoft.ML.Runtime.Api;

namespace Malappo
{
    class BlackFridayData
    {
        // Columns for the data
        [Column("0")]
        public float UserID;

        [Column("1")]
        public float ProductID;

        [Column("2")]
        public float Gender;

        [Column("3")]
        public float Age;

        [Column("4")]
        public float Occupation;

        [Column("5")]
        public float CityCategory;

        [Column("6")]
        public float StayInCurrentCityYears;

        [Column("7")]
        public float MaritalStatus;

        [Column("8")]
        public float ProductCategory1;

        [Column("9")]
        public float ProductCategory2;

        [Column("10")]
        public float ProductCategory3;

        [Column("11")]
        [ColumnName("Label")]
        public string Purchase;

    }
}
