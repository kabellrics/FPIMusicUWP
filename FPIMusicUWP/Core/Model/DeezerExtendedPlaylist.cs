

namespace FPIMusicUWP.Core.ModelDTO
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.1.0 (NJsonSchema v10.7.2.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class DeezerExtendedPlaylist: DeezerPlaylist
    {
        [Newtonsoft.Json.JsonProperty("nbSong", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NbSong { get; set; }

        [Newtonsoft.Json.JsonProperty("nbAlbum", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NbAlbum { get; set; }

        [Newtonsoft.Json.JsonProperty("nbArtiste", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NbArtiste { get; set; }


    }
}