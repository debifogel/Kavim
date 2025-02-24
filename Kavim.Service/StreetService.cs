using Kavim.Core.classes;
using Kavim.Core.repsitory;
using Kavim.Core.Services;

namespace Kavim.Service
{
    public class StreetService: IStreetService
    {
        private readonly IRepository<Street> _streetRepository;
        private readonly IManager _Save;

        public StreetService(IRepository<Street>_repository,IManager save)
        {
            this._streetRepository = _repository;
            _Save = save;
        }

        public async Task<bool> DeleteAsync(int id)
        {
          bool result= _streetRepository.Delete(id);
            if (result)
            {
              await  _Save.SavechangesAync();
                return true;
            }
            return false;
        }

        public IEnumerable<Street> GetAll(string? name, string? city)
        {
            return _streetRepository.GetAll(name,city,null,null);
        }

        public Street GetById(int id)
        {
           return _streetRepository.Get(id);
        }

        public async void PostAsync(NameAndCity busfrombody)
        {
            _streetRepository.Add(new Street(busfrombody.Name, busfrombody.City));
           await _Save.SavechangesAync();
        }

        public async Task<bool> UpDateAsync(int id, NameAndCity street)
        {

            bool result = _streetRepository.UpDate(id, new Street(street.Name,street.City));

            if (result)
            {
               await _Save.SavechangesAync();
                return true; 
            }return false;
        }
        public async Task<bool> AddStationAsync(Station station,int id)
        {
            Street street = _streetRepository.Get(id);
            if (street != null)
            {
                street.ListOfStation.Add(station);
                station.InStreet = street;
               await _Save.SavechangesAync();
                return true;
            }
            return false;
        }

    }
}
