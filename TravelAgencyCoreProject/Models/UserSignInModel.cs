

using System.ComponentModel.DataAnnotations;

namespace TravelAgencyCoreProject.Models
{
    public class UserSignInModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
