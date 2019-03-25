using CarShop.Data;
using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Service
{
    public interface ILocationService
    {
        void Insert(Location entity);
        void Update(Location entity);
        void Delete(Location entity);
        void Delete(Guid id);
        Location Find(Guid id);
        IEnumerable<Location> GetAll();
        IEnumerable<Location> GetAllByName(string name);
        IEnumerable<Location> Search(string name);
    }
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> locationRepository;
        private readonly IUnitOfWork unitOfWork;
        public LocationService(IUnitOfWork unitOfWork, IRepository<Location> locationRepository)
        {
            this.unitOfWork = unitOfWork;
            this.locationRepository = locationRepository;
        }

        public void Delete(Location entity)
        {
            locationRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var location = locationRepository.Find(id);
            if (location != null)
            {
                this.Delete(location);
            }
        }
        public Location Find(Guid id)
        {
            return locationRepository.Find(id);
        }

        public IEnumerable<Location> GetAll()
        {
            return locationRepository.GetAll();
        }

        public IEnumerable<Location> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Location entity)
        {
            locationRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Location> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Location entity)
        {
            var location = locationRepository.Find(entity.Id);  
           
            unitOfWork.SaveChanges();
        }
    }
}
