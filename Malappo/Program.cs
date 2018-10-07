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
                ProductID = "P00190042",
                Gender = "M",
                Age = "54",
                Occupation = "10",
                CityCategory = "C",
                StayInCurrentCityYears = "4",
                MaritalStatus = "0",
                ProductCategory1 = "3",
                ProductCategory2 = "4",
                ProductCategory3 = "5",
                Purchase = "10839"

            });

            // Cw
            System.Console.WriteLine($"User ID is: {prediction.PredictedLabels}");

        }
    }
}
