

using FPIMusicUWP.Core.Model;

namespace FPIMusicUWP.Core.ModelDTO
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.1.0 (NJsonSchema v10.7.2.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class MediathequeSong: Song
    {
        public string ToJson()
        {

            return Newtonsoft.Json.JsonConvert.SerializeObject(this, new Newtonsoft.Json.JsonSerializerSettings());

        }
        public static MediathequeSong FromJson(string data)
        {

            return Newtonsoft.Json.JsonConvert.DeserializeObject<MediathequeSong>(data, new Newtonsoft.Json.JsonSerializerSettings());

        }

    }
}
