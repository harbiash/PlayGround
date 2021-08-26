using System;
using System.Text.Json.Serialization;

namespace PlayGround.WebAPI.Models.ViewModels
{
    public class MessageDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("fields")]
        public Fields Fields { get; init; }
        [JsonPropertyName("createdTime")]
        public DateTime? CreatedTime { get; set; }
    }
}