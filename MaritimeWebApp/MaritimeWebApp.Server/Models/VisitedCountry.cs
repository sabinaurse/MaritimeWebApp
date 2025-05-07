namespace MaritimeWebApp.Server.Models
{
    public class VisitedCountry
    {
        public int Id { get; set; }
        public string CountryName { get; set; }   
        public DateTime VisitDate { get; set; }    


        public int VoyageId { get; set; }
        public Voyage Voyage { get; set; }
    }
}
