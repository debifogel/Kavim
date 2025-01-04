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
        List<Station> GetAll();
        Station GetById(int id);

        public bool DeleteActive(int id);
        public bool Delete(int id);
        public void Post(NameAndCity busfrombody);
        public bool UpDate(int id, Station bus);

    }
}
