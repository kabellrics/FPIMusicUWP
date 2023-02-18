

using FPIMusicUWP.Core.Model;

namespace FPIMusicUWP.Core.ModelDTO
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.1.0 (NJsonSchema v10.7.2.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class DeezerSong : Song
    {

        [Newtonsoft.Json.JsonProperty("artisteId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ArtisteId { get; set; }

        [Newtonsoft.Json.JsonProperty("playlistId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PlaylistId { get; set; }

        public string ToJson()
        {

            return Newtonsoft.Json.JsonConvert.SerializeObject(this, new Newtonsoft.Json.JsonSerializerSettings());

        }
        public static DeezerSong FromJson(string data)
        {

            return Newtonsoft.Json.JsonConvert.DeserializeObject<DeezerSong>(data, new Newtonsoft.Json.JsonSerializerSettings());

        }

    }
}
