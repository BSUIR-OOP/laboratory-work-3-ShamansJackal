using lab3.Transports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab3
{
    public static class JsonService
    {
        public static void ToFile(List<Transport> transports, string path)
        {
            try
            {
                var json = JsonSerializer.Serialize(transports);
                File.WriteAllText(path, json);
            } catch
            {
                File.WriteAllText(path, "Error Serialize");
            }
        }

        public static List<Transport> FromFile(string path)
        {
            try
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Transport>>(json);
            }
            catch
            {
                return new();
            }
        }
    }
}
