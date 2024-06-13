using System.Text.Json.Serialization;

namespace Investing.Services.Models
{
    internal class BrApiError
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }        
    }
}
