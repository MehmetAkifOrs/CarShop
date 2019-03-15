using CarShop.Data;
using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Service
{
    public interface IPageContentService
    {
        void Insert(PageContent entity);
        void Update(PageContent entity);
        void Delete(PageContent entity);
        void Delete(Guid id);
        PageContent Find(Guid id);
        IEnumerable<PageContent> GetAll();
        IEnumerable<PageContent> GetAllByName(string name);
        IEnumerable<PageContent> Search(string name);
    }
    public class PageContentService : IPageContentService
    {
        private readonly IRepository<PageContent> pageContentRepository;
        private readonly IUnitOfWork unitOfWork;
        public PageContentService(IUnitOfWork unitOfWork, IRepository<PageContent> pageContentRepository)
        {
            this.unitOfWork = unitOfWork;
            this.pageContentRepository = pageContentRepository;
        }

        public void Delete(PageContent entity)
        {
            pageContentRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var pageContent = pageContentRepository.Find(id);
            if (pageContent != null)
            {
                this.Delete(pageContent);
            }
        }

        public PageContent Find(Guid id)
        {
            return pageContentRepository.Find(id);
        }

        public IEnumerable<PageContent> GetAll()
        {
            return pageContentRepository.GetAll();
        }

        public IEnumerable<PageContent> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(PageContent entity)
        {
            pageContentRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<PageContent> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(PageContent entity)
        {
            var pageContent = pageContentRepository.Find(entity.Id);
            pageContent.CategoryPagePhoto = entity.CategoryPagePhoto;
            pageContent.CategoryPageHeader = entity.CategoryPageHeader;
            pageContent.CategoryPageDescription = entity.CategoryPageDescription;
            pageContent.AboutPagePhoto = entity.AboutPagePhoto;
            pageContent.AboutPageHeader = entity.AboutPageHeader;
            pageContent.AboutPageDescription = pageContent.AboutPageDescription;
            pageContentRepository.Update(pageContent);
            unitOfWork.SaveChanges();
        }
    }
}
