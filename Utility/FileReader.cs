using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Utility
{
    public class FileReader
    {
        public static List<T> Read<T>(string path)
        {
            var text = File.ReadAllText(path);

            var items = JsonSerializer.Deserialize<List<T>>(text);

            return items;
        }

        public static void Write<T>(string path, IEnumerable<T> items)
        {
            var text = JsonSerializer.Serialize(items);

            File.WriteAllText(path, text);
        }
    }
}
