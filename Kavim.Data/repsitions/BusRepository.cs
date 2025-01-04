using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kavim.Core.classes;
using Kavim.Core.repsitory;
using Kavim.Data.data;
namespace Kavim.Data.repsitions
{
    public class BusRepository : IRepository<Bus>
    {
        IData _context;
        
        public BusRepository(IData context) { _context = context; }
        
        public void Add(Bus item)
        {
            _context.buses.Add(item);
        }
        public bool Delete(Bus item)
        {
            _context.buses.Remove(item);
            return true;
        }
        public bool Delete(int id)
        {
            Bus bus = _context.buses.FirstOrDefault(x => x.Id == id);
            if (bus != null)
            {
                Delete(bus);
                return true;
            }
            return false;
        }


        public Bus Get(int id)
        {
          return  _context.buses.ToList().FirstOrDefault(x => x.Id == id);
        }

        public List<Bus> GetAll(string? name, string? destination, string? source, CompanyName? company)
        {
            return (List<Bus>)_context.buses.Where(bus =>
                    (bus.BusName == null || bus.BusName == name)
                    && (bus.Company == 0 || bus.Company == company)
                     && (destination == null || bus.Destination == destination)
                && (destination == null || bus.Source == source)).ToList();
        }

        public bool UpDate(int id, Bus item)
        {
            Bus b = Get(id);
            if (b != null)
            {
                b.Destination = item.Destination;
                b.Source = item.Source;
                b.IsActive = item.IsActive;
                b.Listofstation = item.Listofstation;
                b.Company = item.Company;
                b.BusName = item.BusName;
                b.Timings = item.Timings;
                return true;

            }
            return false;
        }

    }
}
