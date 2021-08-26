using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PlayGround.WebAPI.Models.ViewModels
{
    public class MessageResponse
    {
        [JsonPropertyName("records")]
        public List<MessageDTO> Records { get; set; }
    }
}