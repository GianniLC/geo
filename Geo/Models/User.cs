using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Versioning;

namespace Geo.Models
{
    public class User
    {
        public int ID { get; set; }

        public int? AbsenceRefId { get; set; }
        public IList<Absence> absences { get; set; }

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

        [Display(Name = "Leftover days")]
        public int daysLeft { get; set; }

        [Display(Name = "Comment")]
        public string? comment { get; set; }

        public string role { get; set; }


        public User(string role = "member")
        {
            // COMMON VALUES

            // Initialize the list for the absences
            this.absences = new List<Absence>();
            // upon creating a user set all the values to 0 
            this.daysPersonal = 0;
            this.daysSick = 0;
            this.daysVacation = 0;

            // 10 free absence days left || TEST PURPOSE
            this.daysLeft = 10;
            this.role = role;
        }
    }
}
