using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PlayGround.WebAPI.Models.ViewModels
{
    public class Record
    {
        [JsonPropertyName("fields")]
        public List<Fields> Fields { get; set; }
    }
}