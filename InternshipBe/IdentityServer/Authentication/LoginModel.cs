using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Authentication
{
    /// <summary>
    /// Model for authorization
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// User email
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email adress")]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
