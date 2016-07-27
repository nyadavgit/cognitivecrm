using System.IO;
using CognitativeCrmVision.Repository;
using Newtonsoft.Json;

namespace CognitativeCrmVision.Services
{
    public class VisionService
    {
        private static readonly VisionRepository VisionRepository = new VisionRepository();

        public string GetJsonResponse(Stream imageStream)
        {
            var jResponse = JsonConvert.SerializeObject(VisionRepository.ProcessImage(imageStream));
            return jResponse;
        }
    }
}
