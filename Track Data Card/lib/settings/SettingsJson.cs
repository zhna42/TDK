using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Track_Data_Card.lib.lib;

namespace Track_Data_Card.lib.settings
{
    class SettingsJson
    {
        public JsonSet json { set; get; }

        public void read()
        {
            string jsonFile = File.ReadAllText("./settings.json");
            json = JsonConvert.DeserializeObject<JsonSet>(jsonFile);
        }

        public void record()
        {
            string jsonText = JsonConvert.SerializeObject(json);
            File.WriteAllText("./settings.json", jsonText);
        }
    }

    class JsonSet
    {
        public string name { get; set; }
        public List<DataJson> data { get; set; }
    }

    class DataJson
    {
        public string nameSettings { get; set; }
        public List<DataSettings> data { get; set; }
    }

    class DataSettings
    {
        public string name { get; set; }
        public string prefix { get; set; }
        public string path { get; set; }
        public string startNumber { get; set; }
    }
}
