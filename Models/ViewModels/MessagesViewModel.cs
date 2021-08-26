using System;
using System.Text.Json.Serialization;

namespace PlayGround.WebAPI.Models.ViewModels
{
    public class MessagesViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title{ get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("receivedAt")]
        public DateTime ReceivedAt { get; set; }
    }
}