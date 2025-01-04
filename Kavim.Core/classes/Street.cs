namespace Kavim.Core.classes
{
    public class Street
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        //one to many
        public List<Station> ListOfStation { get; set; }
        public Street(string name, string city)
        {
            
            Name = name;
            City = city;
            ListOfStation = new List<Station>();
        }
    }
}
