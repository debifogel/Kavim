﻿using Kavim.Core.classes;
using Kavim.Core.repsitory;
using Kavim.Core.Services;

namespace Kavim.Service
{
    public class StreetService: IStreetService
    {
        private readonly IRepository<Street> _streetRepository;
        private readonly IManager _Save;

        public StreetService(IRepository<Street>_repository)
        {
            this._streetRepository = _repository;
           
        }

        public bool Delete(int id)
        {
          bool result= _streetRepository.Delete(id);
            if (result)
            {
                _Save.Savechanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Street> GetAll(string? name, string? city)
        {
            return (List<Street>)_streetRepository.GetAll(name,city,null,null);
        }

        public Street GetById(int id)
        {
           return _streetRepository.Get(id);
        }

        public void Post(NameAndCity busfrombody)
        {
            _streetRepository.Add(new Street(busfrombody.Name, busfrombody.City));
            _Save.Savechanges();
        }

        public bool UpDate(int id, NameAndCity street)
        {

            bool result = _streetRepository.UpDate(id, new Street(street.Name,street.City));

            if (result)
            {
                _Save.Savechanges();
                return true; 
            }return false;
        }
        public bool AddStation(Station station,int id)
        {
            Street street = _streetRepository.Get(id);
            if (street != null)
            {
                street.ListOfStation.Add(station);
                station.StreetId = street;
                _Save.Savechanges();
                return true;
            }
            return false;
        }

    }
}
