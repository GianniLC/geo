using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geo.Models
{
    public class Absence
    {
        [Display(Name = "Form ID")]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int? UserRefId { get; set; }
        public User user { get; set; }

        [ForeignKey("AbsenceType")]
        public int? AbsenceTypeRefID { get; set; }

        // Changes up until this point future me will thank me :)

        [Display(Name = "Enter your name")]
        public string name { get; set; }

        [Display(Name = "Reason of absence")]
        public string absenceReason { get; set; }

        [Display(Name = "Starting date")]
        public DateTime? startDate { get; set; }

        [Display(Name = "Ending date")]
        public DateTime? endDate { get; set; }

        [Display(Name = "Status")]
        public string? approved { get; set; }
    }

    public enum status
    {
        approved,
        rejected,
        review
    }
}
