using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Test_manager.Source.Models;

namespace Test_manager.Source.Services
{
    public static class TestRunsDataStorage
    {
        private const string JsonFilePath = "runs_data.json";

        private static List<TestRunStoreDataModel> GetDataFromJsonFile() {
            string jsonString;
            using (var reader = new StreamReader(JsonFilePath)) {
                jsonString = reader.ReadToEnd();
            }
            //reader.Close();
            return JsonConvert.DeserializeObject<List<TestRunStoreDataModel>>(jsonString);
        }
        
        public static List<TestRunStoreDataModel> GetTestRunsData() {
            return GetDataFromJsonFile();
        }

        public static void AddTestRunData(TestRunStoreDataModel testRunStoreDataData) {
            var testRunsData = GetDataFromJsonFile();
            if ((testRunsData?.Count ?? 0) == 0) {
                testRunsData = new List<TestRunStoreDataModel>();
                testRunStoreDataData.Id = 1;
            } else {
                testRunStoreDataData.Id = testRunsData.Last().Id + 1;
            }
            testRunsData.Add(testRunStoreDataData);
            var jsonString = JsonConvert.SerializeObject(testRunsData);
            using (var outputFile = new StreamWriter(JsonFilePath, false))
            {
                outputFile.WriteLine(jsonString);
                outputFile.Close();
            }
            //File.WriteAllText(JsonFilePath, jsonString);
        }
    }
}