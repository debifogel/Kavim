using Kavim.Core.classes;


namespace Kavim.Core.Services
{
    public interface IBusService
    {

        List<Bus> GetAll(string? name, CompanyName? company, string? destination, string? source);
        Bus GetById(int id);

        public bool DeleteActive(int id);
        public bool Delete(int id);
        public void Post(Busfrombody busfrombody);
        public bool UpDate(int id, Busfrombody bus);
        public bool AddStation(StationAndi station, int id);
    }
}
