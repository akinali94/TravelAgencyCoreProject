

using System.ComponentModel.DataAnnotations;

namespace TravelAgencyCoreProject.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Surname is required")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Username is required")]
		public string Username { get; set; }
		
		[Required(ErrorMessage = "Mail is required")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Please confirm your password")]
		[Compare("Password", ErrorMessage ="Passwords are not compatible")]
		public string ConfirmPassword { get; set; }


	}
}
