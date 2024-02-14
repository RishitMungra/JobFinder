using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JobFinder.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [DisplayName("Is Admin")]
        public bool isAdmin { get; set; }

        [ScaffoldColumn(false)] // Hide these fields from scaffolding
        public DateTime Created { get; set; }

        [ScaffoldColumn(false)] // Hide these fields from scaffolding
        public DateTime Modified { get; set; }
    }
}
