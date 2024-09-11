using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models
{
    
        public class SignInModel
        {
            public string? ReturnUrl { get; set; }

            public IList<AuthenticationScheme>? ExternalLogins { get; set; }


            [Required]
            [EmailAddress]
            public string Email { get; set; }

           
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

    
}
