using System.ComponentModel.DataAnnotations;

namespace Geo.Models
{
    public class Absence
    {
        [Display(Name = "Form ID")]
        public int Id { get; set; }

        [Display(Name = "Enter your name")]
        public string name { get; set; }

        [Display(Name = "Reason of absence")]
        public string absenceType { get; set; }

        [Display(Name = "Starting date")]
        public DateTime? startDate { get; set; }

        [Display(Name = "Ending date")]
        public DateTime? endDate { get; set; }

        [Display(Name = "Status")]
        public string? approved { get; set; }
    }


    public enum AbsenceType
    {
        SICK,
        VACATION,
        PERSONAL
    }
}
