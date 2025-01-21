using Kavim.Core.classes;
using Kavim.Core.repsitory;
using Kavim.Data.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Data.repsitions
{
    public class StationReository : IRepository<Station>
    {
        IData _context;
        public StationReository(IData context)
        {
            _context = context;
        }
        public void Add(Station item)
        {
            _context.stations.Add(item);
        }
        public bool Delete(Station item)
        {
            _context.stations.Remove(item);
            return true;
        }
        public bool Delete(int id)
        {
            Station s = _context.stations.FirstOrDefault(item => item.Id == id);
            if (s != null)
            {
                Delete(s);
                return true;
            }
            return false;
        }
        public Station Get(int id)
        {
            return _context.stations.Include(s=>s.BusInStation).Include(s=>s.BusInStation).FirstOrDefault(station=>station.Id==id);
        }
        public IEnumerable<Station> GetAll(string? name, string? city, string? c, CompanyName? stam)
        {
            return _context.stations.Include(s => s.InStreet);
        }
        public bool UpDate(int id, Station item)
        {
            Station s = Get(id);
            if (s != null)
            {
                if(item.StationName!=null&&item.StationName!="string")
                s.StationName = item.StationName;
                if(item.BusInStation!=null)
                s.BusInStation = item.BusInStation;
                if(item.IsActive != null)
                s.IsActive = item.IsActive;
                if (item.City != null && item.City != "string")
                    s.City = item.City;
                return true;
            }
            return false;

        }
    }
}
