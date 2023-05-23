using System.Collections.Generic;
using System.IO;

namespace WebRegression.Utilities
{
    public class CsvReader
    {
        public List<string> loadCsvFile(string filePath)
        {
            var reader = new StreamReader(File.OpenRead(filePath));
            List<string> searchList = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);
            }
            reader.Dispose();
            return searchList;
   
        }

    }
}
