using System;
using System.Text.Json.Serialization;

namespace Test_App_DOOMM.Models
{
    public class CatFact
    {
        [JsonPropertyName("fact")]
        public string? Fact { get; set; }

        [JsonPropertyName("length")]
        public int? Length { get; set; }
    }
}
