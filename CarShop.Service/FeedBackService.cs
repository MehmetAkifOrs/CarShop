using CarShop.Data;
using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Service
{
    public interface IFeedBackService
    {
        void Insert(FeedBack entity);
        void Update(FeedBack entity);
        void Delete(FeedBack entity);
        void Delete(Guid id);
        FeedBack Find(Guid id);
        IEnumerable<FeedBack> GetAll();
        IEnumerable<FeedBack> GetAllByName(string name);
        IEnumerable<FeedBack> Search(string name);
    }
    public class FeedBackService : IFeedBackService
    {
        private readonly IRepository<FeedBack> feedbackRepository;
        private readonly IUnitOfWork unitOfWork;
        public FeedBackService(IUnitOfWork unitOfWork, IRepository<FeedBack> feedbackRepository)
        {
            this.unitOfWork = unitOfWork;
            this.feedbackRepository = feedbackRepository;
        }

        public void Delete(FeedBack entity)
        {
            feedbackRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var feedback = feedbackRepository.Find(id);
            if (feedback != null)
            {
                this.Delete(feedback);
            }
        }

        public FeedBack Find(Guid id)
        {
            return feedbackRepository.Find(id);
        }

        public IEnumerable<FeedBack> GetAll()
        {
            return feedbackRepository.GetAll();
        }

        public IEnumerable<FeedBack> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(FeedBack entity)
        {
            feedbackRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<FeedBack> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(FeedBack entity)
        {
            var feedback = feedbackRepository.Find(entity.Id);
            feedback.FullName = entity.FullName;
            feedback.Email = entity.Email;
            feedback.Subject = entity.Subject;
            feedback.Message = entity.Message;
            feedbackRepository.Update(feedback);
            unitOfWork.SaveChanges();
        }
    }
}
