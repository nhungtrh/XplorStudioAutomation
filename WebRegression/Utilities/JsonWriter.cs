using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WebRegression.Utilities
{
    public class JsonWriter
    {
        public void jsonWriter_Customer(string value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("Customer", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_Customer_EDB(string value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("Customer", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_Invoice( string value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("Invoice#", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_PaidInvoice(string value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("Invoice#", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_Quotes(String value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("Quote#", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_Items(String value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("ItemName", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_Job(String value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("Job", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_Parent(String value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("Parent", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_WO(String value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("WorkOrder", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }

        }
        public void jsonWriter_Request(String value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("Request#", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_Agreement(string value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("Agreement", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_AgreementCustomer(string value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("CustomerHasAgreement", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_Expenses(string value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("Expenses", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_AgreementPlan(string value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("PlanName", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_NonInventoryItem(String value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("ItemName", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_Assembly(String value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("ItemName", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_DiscountItem(string value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("DiscountItem", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }

        public void jsonWriter_Subtotal(string value, string fileName)
        {
            JObject newData = new JObject(
             new JProperty("SubtotalItem", value));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "\\Resources\\" + fileName + ".json";
            File.WriteAllText(@reportPath, newData.ToString());
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(@reportPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                newData.WriteTo(writer);
            }
        }
    }
}
