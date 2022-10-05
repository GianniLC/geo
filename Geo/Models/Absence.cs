using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geo.Models
{
    public class Absence
    {
        [Display(Name = "Form ID")]
        public int ID { get; set; }

        // the reference to the user able to retrieve the user by calling for this ID
        [Display(Name = "User")]
        public int? UserRefId { get; set; }

        // the reference to the type of absence, able to adjust this later and add more if needed
        public int? AbsenceTypeRefID { get; set; }


        // Changes up until this point future me will thank me :)
        [Display(Name = "Reason of absence")]
        public string? absenceReason { get; set; }

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
