using System;
using System.Configuration;
using System.Data;
using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using CognitativeCrmVision.Repository;
using Newtonsoft.Json;
using RDotNet;
using Microsoft.ProjectOxford.Vision.Contract;

namespace CognitativeCrmVision.Services
{
    public class VisionService
    {
        private static readonly VisionRepository VisionRepository = new VisionRepository();
        private static readonly RnetRepository RnetRepository = new RnetRepository();

        private readonly MlService _mlService = new MlService();

        private string GetJsonResponse(Stream imageStream)
        {
            AnalysisResult analysis = VisionRepository.ProcessImage(imageStream);
            return JsonConvert.SerializeObject(analysis);
         }

        private static DataFrame GetRScriptResult(string jsonResponse, string filePath = null, string scriptFile = null)
        {
            if (scriptFile == null)
            {
                scriptFile = @"R-Scripts\" + ConfigurationManager.AppSettings.Get("FileName");
            }
            var dt = RnetRepository.RunRScript(scriptFile, jsonResponse, filePath);
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

            // create a file

            //string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string filepath = dir + "\\output.txt";

            //try
            //{

            //    // Delete the file if it exists.
            //    if (File.Exists(filepath))
            //    {
            //        File.Delete(filepath);
            //    }

            //    // Create the file.
            //    using (FileStream fs = File.Create(filepath))
            //    {
            //        Byte[] info = new UTF8Encoding(true).GetBytes(jsonResult);
            //        // Add some information to the file.
            //        fs.Write(info, 0, info.Length);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            var df = GetRScriptResult(jsonResult);
            var response = CallMlWebService(df);
            return response;
        }
    }
}
