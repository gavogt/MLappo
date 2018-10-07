using Microsoft.ML.Legacy;
using Microsoft.ML.Legacy.Data;

namespace Malappo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a pipeline and load data
            var pipeline = new LearningPipeline();

            // Set the path to the file
            string data = "BlackFriday.txt";
            pipeline.Add(new TextLoader(data).CreateFrom<BlackFridayData>(separator: ','));

        }
    }
}
