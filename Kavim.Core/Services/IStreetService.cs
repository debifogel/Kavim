using Kavim.Core.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Core.Services
{
    public interface IStreetService
    {
        IEnumerable<Street> GetAll(string? name,string? city);
        Street GetById(int id);

        public  Task<bool> DeleteAsync(int id);
        public void PostAsync(NameAndCity busfrombody);
        public Task<bool> UpDateAsync(int id, NameAndCity street);
        public Task<bool> AddStationAsync(Station station,int id);
    }
}
