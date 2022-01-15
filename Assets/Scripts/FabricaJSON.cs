using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class FabricaJSON
{
    public void EscreverJSON(Partida partida, string caminho)
    {
        JsonSerializer js = new JsonSerializer();
        js.Formatting = Formatting.Indented;
        //if (File.Exists(caminho)) File.Delete(caminho);
        StreamWriter sw = new StreamWriter(caminho);
        JsonWriter jw = new JsonTextWriter(sw);
        js.Serialize(jw, partida);
        jw.Close();
        sw.Close();
    }

    public Partida LerJSON(string caminho)
    {
        JObject obj = null;
        JsonSerializer js = new JsonSerializer();

        if (File.Exists(caminho))
        {
            StreamReader reader = new StreamReader(caminho);
            JsonReader jr = new JsonTextReader(reader);
            obj = js.Deserialize(jr) as JObject;
            jr.Close();
            reader.Close();
        }

        string partidaString = obj.ToString();
        return JsonConvert.DeserializeObject<Partida>(partidaString);
    }
}