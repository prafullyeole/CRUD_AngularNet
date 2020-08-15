using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public class Contact : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Eamil")]
        public string Email { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Phone Number should be less than 10 Digit")]
        public string PhoneNumber { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
