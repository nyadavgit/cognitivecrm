using RDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Principal;

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

            var dt = RDataFrameToDataSet(df);



            string[] cols;
            string[,] vals;
            string test="";
            var valueStrings = new string[df.RowCount];

            var arrValueStrings = new string[1, df.RowCount];

            var strList = new List<string>();

            for (var i = 0; i < df.RowCount; i++)
            {
                for (var j = 0; j < df.ColumnCount; j++)
                {
                    test = test + Convert.ToString(df[j][i]) + ",";
                }

                test = test.Remove(test.Length-1, 1);
                valueStrings[i] = test;

                
                strList.Add(test);
                test = "";
            }

            for (var x = 0; x < valueStrings.Length ; x++)
            {
                arrValueStrings[0, x] = valueStrings[x];
            }


            var arrString = strList.ToArray();

            //Values = new string[,] { {Convert.ToString(valueStrings[0])}  };

            

            

            

            var strArr = new List<string[]> {valueStrings};

            var splitStrArr = strArr.ToArray();

            






            Console.Write("click to finish ...");
            Console.ReadKey();


        }


        private static DataTable RDataFrameToDataSet(DataFrame resultsMatrix)
        {
            var dt = new DataTable();
            var columns = new DataColumn[resultsMatrix.ColumnCount];

            for (var i = 0; i < resultsMatrix.ColumnCount; i++)
            {
                columns[i] = new DataColumn(resultsMatrix.ColumnNames[i], typeof(string));
            }

            dt.Columns.AddRange(columns);

            for (var y = 0; y < resultsMatrix.RowCount; y++)
            {
                var dr = dt.NewRow();
                for (var x = 0; x < resultsMatrix.ColumnCount; x++)
                {
                    try
                    {
                        dr[x] = resultsMatrix[y, x];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
