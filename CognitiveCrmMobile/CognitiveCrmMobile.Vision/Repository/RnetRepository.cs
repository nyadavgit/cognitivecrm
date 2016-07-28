using System;
using System.Data;
using RDotNet;
using System.IO;

namespace CognitativeCrmVision.Repository
{
    public class RnetRepository
    {
        public DataFrame RunRScript(string scriptFile, string jsonResponse, string filepath)
        {
            REngine.SetEnvironmentVariables();
            var engine = REngine.GetInstance();
            engine.Initialize();
          
            var scriptText = File.ReadAllText(scriptFile);
            var myFunc = engine.Evaluate(scriptText).AsFunction();
            //var v1 = engine.CreateCharacter(filepath);
            var jsonTestFile = @"C:\Users\alcerri.NORTHAMERICA\Documents\GitHub\cognitivecrm\cognitivecrm\output10json.txt";
            //var v1 = engine.CreateCharacter(jsonTest);

           var sampleText = File.ReadAllText(jsonTestFile);
            var v1 = engine.CreateCharacter(sampleText.ToString());
            // var v1 = engine.CreateCharacter(jsonResponse);
            var df = myFunc.Invoke(new SymbolicExpression[] { v1 }).AsDataFrame();

            //var dt = RDataFrameToDataSet(df);

            return df;
        }
    }
}
