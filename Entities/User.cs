using System.Text.Json.Serialization;

namespace PlayGround.WebAPI.Entities
{
    public class User
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Username { get; init; }

        [JsonIgnore]
        public string Password { get; init; }
    }
}