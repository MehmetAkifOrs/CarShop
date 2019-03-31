using CarShop.Data;
using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Service
{
    public interface IOrderProductsService
    {
        void Insert(OrderProducts entity);
        void Update(OrderProducts entity);
        void Delete(OrderProducts entity);
        void Delete(Guid id);
        OrderProducts Find(Guid id);
        IEnumerable<OrderProducts> GetAll();
        IEnumerable<OrderProducts> GetAllByName(string name);
        IEnumerable<OrderProducts> Search(string name);
    }
    public class OrderProductsService : IOrderProductsService
    {
        private readonly IRepository<OrderProducts> orderProductsRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderProductsService(IUnitOfWork unitOfWork, IRepository<OrderProducts> orderProductsRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orderProductsRepository = orderProductsRepository;
        }

        public void Delete(OrderProducts entity)
        {
            orderProductsRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var category = orderProductsRepository.Find(id);
            if (category != null)
            {
                this.Delete(category);
            }
        }
        public OrderProducts Find(Guid id)
        {
            return orderProductsRepository.Find(id);
        }

        public IEnumerable<OrderProducts> GetAll()
        {
            return orderProductsRepository.GetAll();
        }

        public IEnumerable<OrderProducts> GetAllByName(string name)
        {
            return orderProductsRepository.GetAll(w => w.ProductName.Contains(name));
        }

        public void Insert(OrderProducts entity)
        {
            orderProductsRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<OrderProducts> Search(string name)
        {
            return orderProductsRepository.GetAll(e => e.ProductName.Contains(name));
        }

        public void Update(OrderProducts entity)
        {
            var orderProducts = orderProductsRepository.Find(entity.Id);
            orderProducts.ProductName = entity.ProductName;
            orderProducts.Priece = entity.Priece;
            orderProducts.Quantity = entity.Quantity;
            orderProducts.TotalPrice = entity.TotalPrice;
            orderProductsRepository.Update(orderProducts);
            unitOfWork.SaveChanges();
        }
    }
}
