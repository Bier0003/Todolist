using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Todolist
{
    public static class FileManager
    {
        

        private static string ProjektList = @"C:\Users\b\HF1database\Todolist\Todolist\todo.json";
        public static void Save(List<Todo> itemList) => File.WriteAllText(ProjektList, JsonConvert.SerializeObject(itemList));
    
        public static List<Todo> ReadFile()
        {
            if (!File.Exists(ProjektList))
            {
                File.Create(ProjektList);
            }

            using (FileStream fs = File.OpenRead(ProjektList))
            {
                string fileJson = File.ReadAllText(ProjektList);
                if (fileJson != null)
                    return JsonConvert.DeserializeObject<List<Todo>>(fileJson);
            }

            return new List<Todo>();
        }
    }
}
