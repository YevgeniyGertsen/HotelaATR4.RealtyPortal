namespace HotelaATR4.Admin.Models
{
    public class TeamLinks
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public string URL { get; set; }
        public int LinkTypeId { get; set; }
    }
}
