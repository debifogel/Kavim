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
       //does it correct???????????????????????????????????????????????????????????????????????
        private readonly IRepository<Station> _station;
        private readonly IManager _Save;
        public BusService(IRepository<Bus> repository, IManager save, IRepository<Station> station)
        {
            _busRepository = repository;
            _Save = save;
            _station = station;
        }
        public async Task<bool> DeleteActiveAsync(int id)
        {
            Bus b = _busRepository.Get(id);
            if (b != null)
            {
                b.IsActive = false;
                 _Save.SavechangesAync(); 
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool result = _busRepository.Delete(id);
            if ((result))
            {
               await _Save.SavechangesAync();
            }
            return result;
        }
        public IEnumerable<Bus> GetAll(string? name, CompanyName? company, string? destination, string? source)
        {
           return _busRepository.GetAll(name,destination,source,company);
        }
        public Bus GetById(int id)
        {
           return _busRepository.Get(id);
                                        
        }
        public  async void PostAsync(Busfrombody busfrombody)
        {
            Bus b = new Bus();

            b.BusName = busfrombody.BusName;
            b.Source = busfrombody.source;
            b.Destination = busfrombody.destination;
            b.Company = busfrombody.Company;
            b.IsActive = true;
            _busRepository.Add(b);
            var r=await _Save.SavechangesAync();

        }
        public async Task<bool> UpDateAsync(int id, Busfrombody bus)
        {
            Bus _bus=new Bus();
            _bus.BusName = bus.BusName;
            _bus.Company = bus.Company;
            _bus.Source=bus.source;
            _bus.Destination=bus.destination;
            
            
            bool result = _busRepository.UpDate(id, _bus);
            if ((result)) {await _Save.SavechangesAync(); }
            return result;
        }
        public async Task<bool> AddStationAsync(StationAndi station, int id)
        {
          Bus b=  _busRepository.Get(id);
            if(b!=null)
            {
               Station s= _station.Get(station.Stop.Id);
                if (s == null)
                    throw new Exception("eror this station not found");
                station.Stop = s;
                station._Bus = b;
                b.Listofstation.Add(station);
                station.Stop.BusInStation.Add(station);
              var r= await  _Save.SavechangesAync() ;
                if(r==1)
                 return true;
            }
            return false;
        }
    }
}
