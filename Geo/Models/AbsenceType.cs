using System.ComponentModel.DataAnnotations;

namespace Geo.Models
{
    public class AbsenceType
    {
        public int ID { get; set; }

        public string TypeOfAbsence { get; set; }

        public string Description { get; set; }
        
    }
}
