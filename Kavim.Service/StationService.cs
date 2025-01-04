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
        
        public bool DeleteActive(int id)
        {
            Station s= _stationRepository.Get(id);
            if (s != null)
            {
                s.IsActive = false;
                _Save.Savechanges();
                return true;
            }
            return false;

        }
        public bool Delete(int id)
        {
            bool result = _stationRepository.Delete(id);
            if (result)
            { 
                _Save.Savechanges();
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

        public void Post(NameAndCity busfrombody)
        {
            _stationRepository.Add(new Station(busfrombody.Name, busfrombody.City));
            _Save.Savechanges();
        }

        public bool UpDate(int id, Station bus)
        {
            bool result = _stationRepository.UpDate(id, bus);
            if ((result))
            {
                
                _Save.Savechanges();
            }
            return false;
        }
        

    }
}
