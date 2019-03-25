using CarShop.Data;
using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Service
{
    public interface IMainPageService
    {
        void Insert(MainPage entity);
        void Update(MainPage entity);
        void Delete(MainPage entity);
        void Delete(Guid id);
        MainPage Find(Guid id);
        IEnumerable<MainPage> GetAll();
        IEnumerable<MainPage> GetAllByName(string name);
        IEnumerable<MainPage> Search(string name);
    }
    public class MainPageService : IMainPageService
    {
        private readonly IRepository<MainPage> mainpageRepository;
        private readonly IUnitOfWork unitOfWork;
        public MainPageService(IUnitOfWork unitOfWork, IRepository<MainPage> mainpageRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mainpageRepository = mainpageRepository;
        }

        public void Delete(MainPage entity)
        {
            mainpageRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var mainpage = mainpageRepository.Find(id);
            if (mainpage != null)
            {
                this.Delete(mainpage);
            }
        }

        public MainPage Find(Guid id)
        {
            return mainpageRepository.Find(id);
        }

        public IEnumerable<MainPage> GetAll()
        {
            return mainpageRepository.GetAll();
        }

        public IEnumerable<MainPage> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(MainPage entity)
        {
            mainpageRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<MainPage> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(MainPage entity)
        {
            var mainpage = mainpageRepository.Find(entity.Id);
            mainpage.MainPagePhoto = entity.MainPagePhoto;
            mainpage.MainPageHeader = entity.MainPageHeader;
            mainpage.MainPageDescription = entity.MainPageDescription;
            mainpageRepository.Update(mainpage);
            unitOfWork.SaveChanges();
        }
    }
}
