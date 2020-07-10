using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RazorPagesUI.Models
{
    public class Joke
    {
        public string Id { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
