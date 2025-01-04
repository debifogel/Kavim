using Kavim.Core.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavim.Core.repsitory
{
    public interface IRepository<T>
    {
        public void Add(T item);
        public bool Delete(T item);
        public bool Delete(int id);
        public List<T> GetAll(string? a, string? b, string? c, CompanyName? company);
        public T Get(int id);
        public  bool UpDate(int id,T item);
    }
}
