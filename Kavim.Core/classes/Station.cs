using System.ComponentModel.DataAnnotations;

namespace Kavim.Core.classes
{
    public class Station
    {//איך אפשר קוד על פי אזור
       
        public int Id { get; set; }
        public string? StationName { get; set; }
        public string? City { get; set; }
        //many to many
        public List<StationAndi>? BusInStation { get; set; }
        public bool? IsActive { get; set; }
        public Street? InStreet { get; set; }
        public Station()
        {
            
            IsActive = true;
        }                              
        public Station(string stationName, string city)
        {
           
            BusInStation = new List<StationAndi>();
            StationName = stationName;
            City = city;
            IsActive = true;
        }
    }
}
