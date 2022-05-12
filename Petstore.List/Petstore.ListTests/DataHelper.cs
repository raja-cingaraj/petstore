using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Petstore.ListTests
{
    public static class DataHelper
    {
        public static string ReadFile(string filePath)
        {
            // Get the absolute path to the JSON file
            var path = Path.IsPathRooted(filePath)
                ? filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(filePath);

            return fileData;
        }

        public static T? ParseData<T>(string filePath)
        {
            string fileContent = ReadFile(filePath);

            return fileContent != null ? JsonSerializer.Deserialize<T>(fileContent) : default;
        }
    }
}
