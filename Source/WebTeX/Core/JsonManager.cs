using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTeX.Core
{
    public static class JsonManager
    {
        public static void SerializeToFile<T>(T obj, string path)
        {
            string? directoryPath = Path.GetDirectoryName(path);
            if (directoryPath == null) return;
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
            File.WriteAllText(path, JsonConvert.SerializeObject(obj));
        }

        public static T? DeserializeFromFile<T>(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }
    }
}
