using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_ChuckNorrisJokes
{
    public class ChuckNorrisAPI
    {
        [JsonProperty("value")]
        public string Joke { get; set; }
    }
}
