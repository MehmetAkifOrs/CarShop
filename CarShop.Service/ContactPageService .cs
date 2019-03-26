using CarShop.Data;
using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Service
{
    public interface IContactPageService
    {
        void Insert(ContactPage entity);
        void Update(ContactPage entity);
        void Delete(ContactPage entity);
        void Delete(Guid id);
        ContactPage Find(Guid id);
        IEnumerable<ContactPage> GetAll();
        IEnumerable<ContactPage> GetAllByName(string name);
        IEnumerable<ContactPage> Search(string name);
    }
    public class ContactPageService : IContactPageService
    {
        private readonly IRepository<ContactPage> contactpageRepository;
        private readonly IUnitOfWork unitOfWork;
        public ContactPageService(IUnitOfWork unitOfWork, IRepository<ContactPage> contactpageRepository)
        {
            this.unitOfWork = unitOfWork;
            this.contactpageRepository = contactpageRepository;
        }

        public void Delete(ContactPage entity)
        {
            contactpageRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var contactpage = contactpageRepository.Find(id);
            if (contactpage != null)
            {
                this.Delete(contactpage);
            }
        }

        public ContactPage Find(Guid id)
        {
            return contactpageRepository.Find(id);
        }

        public IEnumerable<ContactPage> GetAll()
        {
            return contactpageRepository.GetAll();
        }

        public IEnumerable<ContactPage> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(ContactPage entity)
        {
            contactpageRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<ContactPage> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(ContactPage entity)
        {
            var contactpage = contactpageRepository.Find(entity.Id);
            contactpage.ContactPagePhoto = entity.ContactPagePhoto;
            contactpage.ContactPageInformation = entity.ContactPageInformation;
            contactpage.ContactPageAddress = entity.ContactPageAddress;
            contactpage.ContactPageMarketingPhone = entity.ContactPageMarketingPhone;
            contactpage.ContactPageMarketingEmail = entity.ContactPageMarketingEmail;
            contactpage.ContactPageShippingPhone = entity.ContactPageShippingPhone;
            contactpage.ContactPageShippingEmail = entity.ContactPageShippingEmail;
            contactpage.ContactPageInformationPhone = entity.ContactPageInformationPhone;
            contactpage.ContactPageInformationEmail = entity.ContactPageInformationEmail;
            contactpageRepository.Update(contactpage);
            unitOfWork.SaveChanges();
        }
    }
}
