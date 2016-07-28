using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

namespace CognitativeCrmVision.Repository
{
    public class VisionRepository : ImageScenario
    {
        private static async Task<AnalysisResult> UploadAndAnalyzeImage(Stream image)
        {
            //
            // Create Project Oxford Vision API Service client
            //
            var visionServiceClient = new VisionServiceClient(SubscriptionKey);
            var visualFeatures = new VisualFeature[] { VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color, VisualFeature.Description, VisualFeature.Faces, VisualFeature.ImageType, VisualFeature.Tags };
            var analysisResult = await visionServiceClient.AnalyzeImageAsync(image, visualFeatures);
            return analysisResult;
        }

        protected override async Task<AnalysisResult> DoWork(Stream imageStream)
        {
            var analysisResult = await UploadAndAnalyzeImage(imageStream);
            return analysisResult;
        }
    }
}
