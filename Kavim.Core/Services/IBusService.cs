using Kavim.Core.classes;


namespace Kavim.Core.Services
{
    public interface IBusService
    {

        IEnumerable<Bus> GetAll(string? name, CompanyName? company, string? destination, string? source);
        Bus GetById(int id);

        public Task<bool> DeleteActiveAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public void PostAsync(Busfrombody busfrombody);
        public Task<bool> UpDateAsync(int id, Busfrombody bus);
        public Task<bool> AddStationAsync(StationAndi station, int id);
    }
}
