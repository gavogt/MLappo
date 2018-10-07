using Microsoft.ML.Legacy;
using Microsoft.ML.Legacy.Data;
using Microsoft.ML.Legacy.Trainers;
using Microsoft.ML.Legacy.Transforms;
using Microsoft.ML.Transforms;

namespace Malappo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a pipeline and load data
            var pipeline = new LearningPipeline();

            // Set the path to the file
            string data = @"C:\MachineLearningPractice\BlackFriday.csv";
            pipeline.Add(new TextLoader(data).CreateFrom<BlackFridayData>(separator: ','));

            // Transform data
            pipeline.Add(new Dictionarizer("UserID"));

            // Put features into a vector
            pipeline.Add(new ColumnConcatenator("Features", "UserID", "ProductID", "Gender", "Age", "Occupation", "CityCategory", "StayInCurrentCityYears", "MaritalStatus", "ProductCategory1", "ProductCategory2", "ProductCategory3", "Purchase"));

            // Add the learning algorithm to the pipeline
            // Ask which person may buy what
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());

            // Convert label to original text
            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel" });

            // Train the model based on the data set
            var model = pipeline.Train<BlackFridayData, BlackFridayPrediction>();

            // Make a prediction
            var prediction = model.Predict(new BlackFridayData()
            {
                UserID = "1003393",
                ProductID = 0113242,
                Gender = "M",
                Age = "36-45",
                Occupation = "12",
                CityCategory = "C",
                StayInCurrentCityYears = "3",
                MaritalStatus = "1",
                ProductCategory1 = "1",
                ProductCategory2 = "6",
                ProductCategory3 = "8",
                Purchase = default

            });

            // Cw
            System.Console.WriteLine($"User ID is: {prediction.Purchase}");

        }
    }
}
