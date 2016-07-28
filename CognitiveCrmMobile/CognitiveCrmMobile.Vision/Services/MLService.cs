using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RDotNet;
using CognitativeCrmVision.Models;

namespace CognitativeCrmVision.Services
{
    public class MlService
    {
        public async Task<string> RunInvokeApi(DataFrame dataFrame)
        {
            var response = await InvokeRequestResponseService(dataFrame);
            return response;
        }

        private static async Task<string> InvokeRequestResponseService(DataFrame dataFrame)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = dataFrame.ColumnNames,
                                Values = GetStringArrays(ref dataFrame)
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "CLS0/Nbzj14AQHLdU6FGAZGhuf+W4us9G2v3zMsE4UNpdSzCw5/xvItjIpldVh3Fn77NMvR3j3bwcIqZiKZ8oA=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/5662c016c51e4284bd73e197c362210e/services/96072a9e3be84960a92bb40552b14014/execute?api-version=2.0&details=true");

                var response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
            }
        }
        private static string[,] GetStringArrays(ref DataFrame dataFrame)
        {
            var valueStrings = new string[dataFrame.RowCount];
            var delimiterAndValues = "";
            var arrValueStrings = new string[1, dataFrame.RowCount];

            for (var i = 0; i < dataFrame.RowCount; i++)
            {
                for (var j = 0; j < dataFrame.ColumnCount; j++)
                {
                    delimiterAndValues = delimiterAndValues + Convert.ToString(dataFrame[j][i]) + ",";
                }

                delimiterAndValues = delimiterAndValues.Remove(delimiterAndValues.Length - 1, 1);
                valueStrings[i] = delimiterAndValues;
                delimiterAndValues = "";
            }

            for (var x = 0; x < valueStrings.Length; x++)
            {
                arrValueStrings[0, x] = valueStrings[x];
            }

            return arrValueStrings;
        }
    }
}
