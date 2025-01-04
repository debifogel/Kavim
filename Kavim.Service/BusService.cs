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
    public class BusService : IBusService
    {
        private readonly IRepository<Bus> _busRepository;
        private readonly IManager _Save;

        public BusService(IRepository<Bus> repository, IManager save)
        {
            _busRepository = repository;
            _Save = save;
        }

        public bool DeleteActive(int id)
        {
            Bus b = _busRepository.Get(id);
            if (b != null)
            {
                b.IsActive = false;
                _Save.Savechanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            bool result = _busRepository.Delete(id);
            if ((result))
            {
                _Save.Savechanges();
            }
            return result;
        }
        public List<Bus> GetAll(string? name, CompanyName? company, string? destination, string? source)
        {
           return (List<Bus>)_busRepository.GetAll(name,destination,source,company);
        }

        public Bus GetById(int id)
        {
           return _busRepository.Get(id);
                                        
        }

        public void Post(Busfrombody busfrombody)
        {
            Bus b = new Bus();

            b.BusName = busfrombody.BusName;
            b.Source = busfrombody.source;
            b.Destination = busfrombody.destination;
            b.Company = busfrombody.Company;
            b.IsActive = true;
            _busRepository.Add(b);
            _Save.Savechanges();

        }

        public bool UpDate(int id, Busfrombody bus)
        {
            Bus _bus=new Bus();
            _bus.BusName = bus.BusName;
            _bus.Company = bus.Company;
            _bus.Source=bus.source;
            _bus.Destination=bus.destination;
            
            
            bool result = _busRepository.UpDate(id, _bus);
            if ((result)) {_Save.Savechanges(); }
            return result;
        }
        public bool AddStation(StationAndi station, int id)
        {
          Bus b=  _busRepository.Get(id);
            if(b!=null)
            {
                b.Listofstation.Add(station);
                station.Stop.BusInStation.Add(b);
                _Save.Savechanges() ;
                return true;
            }
            return false;
        }
    }
}
