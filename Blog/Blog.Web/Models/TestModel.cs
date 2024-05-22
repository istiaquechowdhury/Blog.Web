using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models
{
    public class TestModel
    {
        [Required]
        public string Name { get; set; }

        [Required,EmailAddress(ErrorMessage ="Please Provide valid Email Address")]
        public string Email { get; set; }   

        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        public string ConfirmPassword { get; set; } 
    }
}
