using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    class Program
    {
        private static Stream GetStream(string filePath)
        {
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string file = dir + filePath;

            Stream fs = File.OpenRead(file);
            return fs;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Let's Run");
            Console.Read();
            var service = new CognitativeCrmVision.Services.VisionService();
            var stream = GetStream(@"\002.jpg");
            string result = service.CognitiveResult(stream);
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
