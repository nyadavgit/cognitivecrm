using System.IO;
using System.Threading.Tasks;

using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

namespace CognitativeCrmVision.Repository
{
    public class VisionRepository : ImageScenario
    {
        //public async Task<AnalysisResult> UploadAndAnalyzeImage(string imageFilePath)
        private static async Task<AnalysisResult> UploadAndAnalyzeImage(Stream image)
        {
            // -----------------------------------------------------------------------
            // KEY SAMPLE CODE STARTS HERE
            // -----------------------------------------------------------------------

            //
            // Create Project Oxford Vision API Service client
            //

            var visionServiceClient = new VisionServiceClient(SubscriptionKey);
            const string imageFilePath = "\\\\NIRAJ-PC\\Hackathon\\SampleImages\\Canon\\006.jpg";

            using (Stream imageFileStream = File.OpenRead(imageFilePath))
            {
                //
                // Analyze the image for all visual features
                //
                
                var visualFeatures = new VisualFeature[] { VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color, VisualFeature.Description, VisualFeature.Faces, VisualFeature.ImageType, VisualFeature.Tags };
                var analysisResult = await visionServiceClient.AnalyzeImageAsync(imageFileStream, visualFeatures);
                return analysisResult;
            }

            // -----------------------------------------------------------------------
            // KEY SAMPLE CODE ENDS HERE
            // -----------------------------------------------------------------------
        }

        protected override async Task<AnalysisResult> DoWork(Stream imageStream)
        {
            var analysisResult = await UploadAndAnalyzeImage(imageStream);
            return analysisResult;
        }
    }
}
