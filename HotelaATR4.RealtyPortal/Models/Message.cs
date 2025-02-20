using System.ComponentModel.DataAnnotations;

namespace HotelaATR4.RealtyPortal.Models
{
    public class Message
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Email is not coorect")]
        public string Email { get; set; }
        public string MessageBody { get; set; }

        [CustomDate]
        public DateTime DOB { get; set; }

        [NameValidate(NotAllowed = new string[] {"Almaty" }, 
            ErrorMessage = "Not Allowed for this city")]
        public string City { get; set; }
    }
}
