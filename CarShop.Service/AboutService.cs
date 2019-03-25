using CarShop.Data;
using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Service
{
    public interface IAboutService
    {
        void Insert(About entity);
        void Update(About entity);
        void Delete(About entity);
        void Delete(Guid id);
        About Find(Guid id);
        IEnumerable<About> GetAll();
        IEnumerable<About> GetAllByName(string name);
        IEnumerable<About> Search(string name);
    }
    public class AboutService : IAboutService
    {
        private readonly IRepository<About> aboutRepository;
        private readonly IUnitOfWork unitOfWork;
        public AboutService(IUnitOfWork unitOfWork, IRepository<About> aboutRepository)
        {
            this.unitOfWork = unitOfWork;
            this.aboutRepository = aboutRepository;
        }

        public void Delete(About entity)
        {
            aboutRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var about = aboutRepository.Find(id);
            if (about != null)
            {
                this.Delete(about);
            }
        }

        public About Find(Guid id)
        {
            return aboutRepository.Find(id);
        }

        public IEnumerable<About> GetAll()
        {
            return aboutRepository.GetAll();
        }

        public IEnumerable<About> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(About entity)
        {
            aboutRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<About> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(About entity)
        {
            var about = aboutRepository.Find(entity.Id);
            about.AboutPagePhoto = entity.AboutPagePhoto;
            about.AboutPageHeader = entity.AboutPageHeader;
            about.AboutPageDescription = about.AboutPageDescription;
            aboutRepository.Update(about);
            unitOfWork.SaveChanges();
        }
    }
}
