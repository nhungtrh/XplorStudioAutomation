using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace WebRegression.Utilities
{
    public class JsonReader
    {

        public string jsonReader(string fileName, object itemName)
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json"; 

            // JObject o1 = JObject.Parse(File.ReadAllText(reportPath));
            StreamReader file = File.OpenText(reportPath);
            JsonTextReader reader = new JsonTextReader(file);
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                dynamic fileContents = JArray.Parse("[" + o2.ToString() + "]");
                dynamic fileContent = fileContents[0];
                var value = o2[itemName].ToString();
                return value;
            }
        }

    }

}