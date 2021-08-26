using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlayGround.WebAPI.Models.ViewModels
{
    public class CreateMessageRequest
    {
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [Required]
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}