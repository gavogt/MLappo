using Microsoft.ML.Legacy;
using Microsoft.ML.Legacy.Data;
using Microsoft.ML.Legacy.Trainers;
using Microsoft.ML.Legacy.Transforms;

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
            pipeline.Add(new TextLoader(data).CreateFrom<BlackFridayData>(useHeader: true, separator: ','));

            // Transform data
            pipeline.Add(new Dictionarizer("Label"));

            // Put features into a vector
            pipeline.Add(new ColumnConcatenator("Features", "UserID", "ProductID", "Gender", "Age", "Occupation", "CityCategory", "StayInCurrentCityYears", "MaritalStatus", "ProductCategory1", "ProductCategory2", "ProductCategory3"));

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
                UserID = 1003393f,
                ProductID = 100182642f,
                Gender = 1f,
                Age = 36345f,
                Occupation = 14f,
                CityCategory = 0f,
                StayInCurrentCityYears = 1f,
                MaritalStatus = 1f,
                ProductCategory1 = 1f,
                ProductCategory2 = 6f,
                ProductCategory3 = 8f,


            });

            // Cw
            System.Console.WriteLine($"Purchase prediction is: {prediction.PredictedPurchases}");

        }
    }
}
