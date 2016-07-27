using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;

namespace CognitativeCrmVision.Repository
{
    public abstract class ImageScenario
    {
        protected static string SubscriptionKey => ConfigurationManager.AppSettings.Get("SubscriptionKey");

        /// <summary>
        /// Perform the work for this scenario
        /// </summary>
        /// <param name="imageStream"></param>
        /// <returns></returns>
        protected abstract Task<AnalysisResult> DoWork(Stream imageStream);
        public async Task<AnalysisResult> ProcessImage(Stream imageStream)
        {
            return await DoWork(imageStream);
        }

    }
}
