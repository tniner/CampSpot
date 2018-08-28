using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParseJson
{
    public class ParseFile<T>
    {
        public T ReadJsonFile(string fileName)
        {
            using (StreamReader file = File.OpenText(fileName))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    var serial = new JsonSerializer();
                    return serial.Deserialize<T>(reader);

                }
            }
        }

    }
}
