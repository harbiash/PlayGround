using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PlayGround.WebAPI.Models.ViewModels
{
    public class Fields
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }
        public string Summary { get; init; }
        public string Message { get; init; }
        [JsonPropertyName("receivedAt")]
        public DateTime ReceivedAt { get; init; }
    }
}