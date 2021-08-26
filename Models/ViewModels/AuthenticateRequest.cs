using System.ComponentModel.DataAnnotations;

namespace PlayGround.WebAPI.Models.ViewModels
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}