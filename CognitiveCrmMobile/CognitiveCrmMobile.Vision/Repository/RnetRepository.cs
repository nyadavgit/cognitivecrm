using RDotNet;
using System.IO;

namespace CognitativeCrmVision.Repository
{
    public class RnetRepository
    {
        public DataFrame RunRScript(string scriptFile, string jsonResponse)
        {
            REngine.SetEnvironmentVariables();
            var engine = REngine.GetInstance();
            engine.Initialize();

            var text = File.ReadAllText(scriptFile);
            var myFunc = engine.Evaluate(text).AsFunction();
            var v1 = engine.CreateCharacter(jsonResponse);
            var df = myFunc.Invoke(new SymbolicExpression[] { v1 }).AsDataFrame();

            return df;
        }
    }
}
