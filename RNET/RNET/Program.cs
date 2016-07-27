using RDotNet;
using System;
using System.IO;

namespace RNET
{
    class Program
    {
        static void Main(string[] args)
        {
            var scriptFile = @"C:\projects\Hackathon\crmcognitive\R-scripts\Data_Grouping.r";
            var jsonResponse = @"C:\projects\Hackathon\crmcognitive\R-scripts\output10json.txt";

            if (args.Length > 0)
            {
                scriptFile = args[0];
                jsonResponse = args[1];
            }

            Console.Write("click to start ...");
            Console.ReadKey();

            REngine.SetEnvironmentVariables();
            REngine engine = REngine.GetInstance();
            engine.Initialize();

            string text = File.ReadAllText(scriptFile);
            var myFunc = engine.Evaluate(text).AsFunction();
            var v1 = engine.CreateCharacter(jsonResponse);
            var df = myFunc.Invoke(new SymbolicExpression[] { v1 }).AsDataFrame();

            Console.Write("click to finish ...");
            Console.ReadKey();


        }
    }
}
