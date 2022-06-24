using System.ComponentModel.DataAnnotations;

namespace Geo.Models
{
    public class User
    {
        public int id { get; set; }

        [Display(Name = "First name")]
        public string fname { get; set; }

        [Display(Name = "Last name")]
        public string lname { get; set; }

        [Display(Name = "Vacation")]
        public int daysVacation { get; set; }

        [Display(Name = "Sick")]
        public int daysSick { get; set; }

        [Display(Name = "Personal")]
        public int daysPersonal { get; set; }

        [Display(Name = "Comment")]
        public string comment { get; set; }


    }
}
