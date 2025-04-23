using System.ComponentModel.DataAnnotations;

namespace HotelaATR4.Admin.Models
{
    public class Team
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }


        public string ImagePath { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }        
    }
}
