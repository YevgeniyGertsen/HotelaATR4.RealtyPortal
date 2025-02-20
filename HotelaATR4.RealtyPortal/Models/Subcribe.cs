using System.ComponentModel.DataAnnotations;

namespace HotelaATR4.RealtyPortal.Models
{
    public class Subcribe
    {
        [Required()]
        public string email { get; set; }
        public int formId { get; set; }
    }
}
