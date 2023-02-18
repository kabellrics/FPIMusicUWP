using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Core.Model
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.1.0 (NJsonSchema v10.7.2.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class PlayerListStatus
    {
        [Newtonsoft.Json.JsonProperty("songAlreadyPlay", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Song> SongAlreadyPlay { get; set; }

        [Newtonsoft.Json.JsonProperty("songToPlay", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Song> SongToPlay { get; set; }

        [Newtonsoft.Json.JsonProperty("currentSong", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Song CurrentSong { get; set; }

        [Newtonsoft.Json.JsonProperty("playing", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Playing { get; set; }

        [Newtonsoft.Json.JsonProperty("pausing", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Pausing { get; set; }

        [Newtonsoft.Json.JsonProperty("isShuffle", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsShuffle { get; set; }

    }
}
