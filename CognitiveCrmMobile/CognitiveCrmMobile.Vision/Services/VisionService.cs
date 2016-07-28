using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using CognitativeCrmVision.Repository;
using Newtonsoft.Json;
using RDotNet;

namespace CognitativeCrmVision.Services
{
    public class VisionService
    {
        private static readonly VisionRepository VisionRepository = new VisionRepository();
        private static readonly RnetRepository RnetRepository = new RnetRepository();

        private readonly MlService _mlService = new MlService();

        private string GetJsonResponse(Stream imageStream)
        {
            var jResponse = JsonConvert.SerializeObject(VisionRepository.ProcessImage(imageStream));
            return jResponse;
        }

        private static DataFrame GetRScriptResult(string jsonResponse, string scriptFile = null)
        {
            if (scriptFile == null)
            {
                scriptFile = @"R-Scripts\" + ConfigurationManager.AppSettings.Get("FileName");
            }
            var dt = RnetRepository.RunRScript(scriptFile, jsonResponse);
            return dt;
        }

        private string CallMlWebService(DataFrame df)
        {
            var response = _mlService.RunInvokeApi(df);
            return response.Result;

        }
        public string CognitiveResult(Stream imageStream)
        {
            var jsonResult = GetJsonResponse(imageStream);

            var df = GetRScriptResult(jsonResult);

            var response = CallMlWebService(df);

            return response;
        }
    }
}
