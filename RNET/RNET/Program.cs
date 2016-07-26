using RDotNet;
using System;
using System.IO;

namespace RNET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("click to start ...");
            Console.ReadKey();

            REngine.SetEnvironmentVariables();
            REngine engine = REngine.GetInstance();
            engine.Initialize();

            string text = File.ReadAllText(@"C:\dev\github\cognitivecrm\R-scripts\Data_Grouping.r");
            var myFunc = engine.Evaluate(text).AsFunction();
            var v1 = engine.CreateCharacter(@"C:\dev\github\cognitivecrm\R-scripts\output10json.txt");
            var df = myFunc.Invoke(new SymbolicExpression[] { v1 }).AsDataFrame();

            Console.Write("click to finish ...");
            Console.ReadKey();


        }
    }
}
