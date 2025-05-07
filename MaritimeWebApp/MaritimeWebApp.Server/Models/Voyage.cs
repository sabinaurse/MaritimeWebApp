using System.ComponentModel.DataAnnotations.Schema;

namespace MaritimeWebApp.Server.Models
{
    public class Voyage
    {
        public int Id { get; set; }
        public DateTime VoyageDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public int ShipId { get; set; }
        public Ship Ship { get; set; }

        public int DeparturePortId { get; set; }
        public Port DeparturePort { get; set; }

        public int ArrivalPortId { get; set; }
        public Port ArrivalPort { get; set; }

        public ICollection<VisitedCountry>? VisitedCountries { get; set; }
    }
}
