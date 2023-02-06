using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Contact : BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
