using Kavim.Core.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Core.Services
{
    public interface IStationService
    {
        IEnumerable<Station> GetAll();
        Station GetById(int id);

        public Task<bool> DeleteActiveAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public void PostAsync(NameAndCity busfrombody);
        public Task<bool> UpDateAsync(int id, Station bus);

    }
}
