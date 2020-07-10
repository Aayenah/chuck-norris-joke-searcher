using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RazorPagesUI.Models
{
    public class RootJsonObject
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("result")]
        public List<Joke> Results { get; set; }
    }
}
