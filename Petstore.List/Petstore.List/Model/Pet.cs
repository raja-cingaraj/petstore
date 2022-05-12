using System.Text.Json.Serialization;

namespace Petstore.List.Model
{
    public class Pet
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
