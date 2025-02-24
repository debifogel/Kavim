using Kavim.Core.classes;
using Kavim.Core.repsitory;
using Kavim.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Service
{
    public class StationService : IStationService
    {
        private readonly IRepository<Station> _stationRepository;
        private readonly IManager _Save;
        public StationService(IRepository<Station>repository,IManager save)
        {
            _stationRepository = repository;
            _Save = save;
        }
        
        public async Task<bool> DeleteActiveAsync(int id)
        {
            Station s= _stationRepository.Get(id);
            if (s != null)
            {
                s.IsActive = false;
               await  _Save.SavechangesAync();
                return true;
            }
            return false;

        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool result = _stationRepository.Delete(id);
            if (result)
            {
                await _Save.SavechangesAync();
                return true;
            }
            return false;
        }
        public IEnumerable<Station> GetAll()
        {
          return  _stationRepository.GetAll(null,null,null,null);
        }

        public Station GetById(int id)
        {
           return _stationRepository.Get(id);
        }

        public async void PostAsync(NameAndCity busfrombody)
        {
            _stationRepository.Add(new Station(busfrombody.Name, busfrombody.City));
            await _Save.SavechangesAync();
        }

        public async Task<bool> UpDateAsync(int id, Station bus)
        {
            bool result = _stationRepository.UpDate(id, bus);
            if ((result))
            {

               await _Save.SavechangesAync();
            }
            return false;
        }
        

    }
}
