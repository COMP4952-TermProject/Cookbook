using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TechnicalProgrammingProject.Attributes;

namespace TechnicalProgrammingProject.Models
{
    public class ProfileViewModel
    {
        public string ID { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Biography { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] ProfilePicture { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
    }

    public class EditProfileViewModel
    {
        [StringLength(50)]
        public string DisplayName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [StringLength(250)]
        public string Biography { get; set; }
        [Date]
        public DateTime? DateOfBirth { get; set; }
        [Image]
        public HttpPostedFileBase ProfilePicture { get; set; }
        public byte[] Image { get; set; }
        [Range(0, 250)]
        public int? Age { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}