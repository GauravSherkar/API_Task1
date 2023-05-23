using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class AddEventRequest
    {
        [Key]
        public int uid { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string tagline { get; set; }
        public DateTime? Schedule { get; set; }
        public string description { get; set; }
        public string files { get; set; }
        public string moderator { get; set; }

        public string category { get; set; }
        public string sub_category { get; set; }
        public int rigor_rank { get; set; }
        public int attendees { get; set; }
    }
}
