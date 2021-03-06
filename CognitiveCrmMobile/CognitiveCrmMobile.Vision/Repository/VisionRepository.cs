﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using System.Configuration;

namespace CognitativeCrmVision.Repository
{
    public class VisionRepository //: ImageScenario
    {


        private static async Task<OcrResults> UploadAndAnalyzeImage(Stream image)
        {
            //
            // Create Project Oxford Vision API Service client
            //
            string SubscriptionKey = ConfigurationManager.AppSettings.Get("SubscriptionKey");
            var visionServiceClient = new VisionServiceClient(SubscriptionKey);
            //var visualFeatures = new VisualFeature[] { VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color, VisualFeature.Description, VisualFeature.Faces, VisualFeature.ImageType, VisualFeature.Tags };
            //return await visionServiceClient.AnalyzeImageAsync(image, visualFeatures);

            OcrResults ocrResult = await visionServiceClient.RecognizeTextAsync(image, "unk");
            return ocrResult;

            //return analysisResult;
        }

        //protected override async Task<AnalysisResult> DoWork(Stream imageStream)
        //{
        //    AnalysisResult analysisResult = await UploadAndAnalyzeImage(imageStream);
        //    return analysisResult;
        //}

        public OcrResults ProcessImage(Stream imageStream)
        {
            return UploadAndAnalyzeImage(imageStream).Result;
        }
        
    }
}
