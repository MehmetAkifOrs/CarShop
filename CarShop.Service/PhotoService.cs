using CarShop.Data;
using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Service
{
    public interface IPhotoService
    {
        void Insert(Photo entity);
        void Update(Photo entity);
        void Delete(Photo entity);
        void Delete(Guid id);
        Photo Find(Guid id);
        IEnumerable<Photo> GetAll();
        IEnumerable<Photo> GetAllByName(string name);
        IEnumerable<Photo> Search(string name);
    }
    public class PhotoService : IPhotoService
    {
        private readonly IRepository<Photo> photoRepository;
        private readonly IUnitOfWork unitOfWork;
        public PhotoService(IUnitOfWork unitOfWork, IRepository<Photo> photoRepository)
        {
            this.unitOfWork = unitOfWork;
            this.photoRepository = photoRepository;
        }

        public void Delete(Photo entity)
        {
            photoRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var photo = photoRepository.Find(id);
            if (photo != null)
            {
                this.Delete(photo);
            }
        }
        public Photo Find(Guid id)
        {
            return photoRepository.Find(id);
        }

        public IEnumerable<Photo> GetAll()
        {
            return photoRepository.GetAll();
        }

        public IEnumerable<Photo> GetAllByName(string name)
        {
            return photoRepository.GetAll(w => w.Name.Contains(name));
        }

        public void Insert(Photo entity)
        {
            photoRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Photo> Search(string name)
        {
            return photoRepository.GetAll(e => e.Name.Contains(name));
        }

        public void Update(Photo entity)
        {
            var photo = photoRepository.Find(entity.Id);
            photo.Name = entity.Name;           
            unitOfWork.SaveChanges();
        }
    }
}
