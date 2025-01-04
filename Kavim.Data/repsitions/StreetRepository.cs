using Kavim.Core.classes;
using Kavim.Core.repsitory;
using Kavim.Data.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Data.repsitions
{
    public class StreetRepository : IRepository<Street>
    {
        private readonly IData _context;
        public StreetRepository(IData context)
        {
            _context = context;
        }
        public void Add(Street item)
        {
            _context.streets.Add(item);
        }

        public bool Delete(Street item)
        {
            _context.streets.Remove(item);
            return true;
        }
        public bool Delete(int id)
        {
            Street s = _context.streets.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                Delete(s);
                return true;
            }
            return false;
        }
        public Street Get(int id)
        {
            return _context.streets.ToList().FirstOrDefault(street=>street.Id == id);
        }

        public List<Street> GetAll(string? name, string? city, string? c, CompanyName? stam)
        {
            return (List<Street>)_context.streets.Where(item => (city == null || item.City == city) && (name == null || item.Name == name)).ToList();
        }
        public bool UpDate(int id, Street item)
        {
            Street s=Get(id);
            if (s != null)
            {
                s.Name = item.Name;
                s.ListOfStation = item.ListOfStation;
                s.City = item.City;
                return true;
            }
            return false;
        }





    }
}
