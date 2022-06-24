using System.ComponentModel.DataAnnotations;

namespace Geo.Models
{
    public class Absence
    {
        public int id { get; set; }

        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }

        public string[] reason = {"isPersonal", "isSick", "isVacation"};

        private User user; 

        public Absence()
        {
            // which reason do we submit the absence for?
            user.daysPersonal = +1;
        }

    }
}
