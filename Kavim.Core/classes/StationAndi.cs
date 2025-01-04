

namespace Kavim.Core.classes
{
    public enum StatusOfStation
    {
        הורדה,
        עליה,
        רגיל
    }
    public class StationAndi
    {
        
        public int Id { get; set; }
        public StatusOfStation Status { get; set; }
        public int InOrder {  get; set; }
        public Station Stop { get; set; }
        
        

    }
}
