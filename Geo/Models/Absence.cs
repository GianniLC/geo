using System.ComponentModel.DataAnnotations;

namespace Geo.Models
{
    public class Absence
    {
        public int id { get; set; }

        public DateTime? dateStart { get; set; }
        public DateTime? dateEnd { get; set; }

        [Display(Name = "Type of absence")]
        public AbsenceTypes AbsenceTypes { get; set; }

        
        public User user; 
    }
}
