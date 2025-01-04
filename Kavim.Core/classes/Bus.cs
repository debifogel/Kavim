namespace Kavim.Core.classes
{
    public enum CompanyName
    {
        Dan, Afikim, Eged,Superbus
    };
    //להוסיף  enum ושמות ליעד ומוצא
    public class Bus
    {
        
        public int Id { get; set; }
        public string BusName { get; set; }
        public string Destination { get; set; }
        public string Source { get; set; }
        
        public CompanyName Company { get; set; }
        public bool IsActive { get; set; }
        //many to many
       public List<StationAndi> Listofstation { get; set; }
        //one to many
        public List<Schdule>  Timings { get; set; }
        
        public Bus()
        {
            Listofstation= new List<StationAndi>();
            Timings= new List<Schdule>();
        }


    }
}
