using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHikeB.Models
{
    public class Customer : IdentityUser
    {
        [Required]
        [PersonalData]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [PersonalData]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [PersonalData]
        [Display(Name = "Personal student ID (on the back of your student card)")]
        public int StudentID { get; set; }
        [Required]
        [ProtectedPersonalData]
        [DataType(DataType.EmailAddress)]
        override public string Email { get; set; }
        [Required]
        [ProtectedPersonalData]
        [Display(Name = "Phone number")]
        override public string PhoneNumber { get; set; }

        
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare(nameof(Password))]
        [Display(Name = "Retype password")]
        public string PasswordControl { get; set; }
        public bool Verified { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
