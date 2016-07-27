using System.Configuration;
using System.Data;
using System.IO;
using CognitativeCrmVision.Repository;
using Newtonsoft.Json;
using RDotNet;

namespace CognitativeCrmVision.Services
{
    public class VisionService
    {
        private static readonly VisionRepository VisionRepository = new VisionRepository();
        private static readonly RnetRepository RnetRepository = new RnetRepository();

        private string GetJsonResponse(Stream imageStream)
        {
            var jResponse = JsonConvert.SerializeObject(VisionRepository.ProcessImage(imageStream));
            return jResponse;
        }

        private DataFrame GetRScriptResult(string jsonResponse, string scriptFile = null)
        {
            if (scriptFile == null)
            {
                scriptFile = ConfigurationManager.AppSettings.Get("FilePath") + @"\" +
                             ConfigurationManager.AppSettings.Get("FileName");
            }
            var dt = RnetRepository.RunRScript(scriptFile, jsonResponse);
            return dt;
        }
    }
}
