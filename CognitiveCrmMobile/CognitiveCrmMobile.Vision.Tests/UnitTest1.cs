using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CognitativeCrmVision.Services;
using System.IO;
using System.Threading.Tasks;

namespace CognitiveCrmMobile.Vision.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Stream GetStream(string filePath)
        {
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string file = dir + filePath;

            Stream fs = File.OpenRead(file);
            return fs;
        }

        private async Task<string> CognitiveTestAsync()
        {
            var service = new CognitativeCrmVision.Services.VisionService();
            var stream = GetStream(@"\one.jpg");
            var task = service.CognitiveResult(stream);
            return await task;
        }

        [TestMethod]
        public void CognitiveTest()
        {

            var task = new Task<string>(CognitiveTestAsync);
            task.Start();
            task.Wait();
            Console.ReadLine();
        }
    }
}
