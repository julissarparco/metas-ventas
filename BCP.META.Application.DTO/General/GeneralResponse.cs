using System.Text.Json.Serialization;

namespace BCP.META.Application.DTO.General
{
    public class GeneralResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}