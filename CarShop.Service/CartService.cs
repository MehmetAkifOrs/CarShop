using CarShop.Data;
using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Service
{
    public interface ICartService
    {
        void Insert(Cart entity);
        void Update(Cart entity);
        void Delete(Cart entity);
        void Delete(Guid id);
        Cart Find(Guid id);
        IEnumerable<Cart> GetAll();
        IEnumerable<Cart> GetAllByName(string name);
        //IEnumerable<Cart> Search(string name);
    }
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> cartRepository;
        private readonly IUnitOfWork unitOfWork;
        public CartService(IUnitOfWork unitOfWork, IRepository<Cart> cartRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cartRepository = cartRepository;
        }

        public IEnumerable<Cart> GetAll()
        {
            return cartRepository.GetAll();
        }

        public IEnumerable<Cart> GetAllByName(string name)
        {
            return cartRepository.GetAll(w => w.ProductName.Contains(name));
        }



        //public IEnumerable<Cart> Search(string name)
        //{
        //    return cartRepository.GetAll(e => e.Name.Contains(name));
        //}




        public void Delete(Cart entity)
        {
            cartRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var cart = cartRepository.Find(id);
            if (cart != null)
            {
                this.Delete(cart);
            }
        }

        public Cart Find(Guid id)
        {
            return cartRepository.Find(id);
        }

        public void Insert(Cart entity)
        {
            cartRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public void Update(Cart entity)
        {
            var cart = cartRepository.Find(entity.Id);

            cartRepository.Update(cart);
            unitOfWork.SaveChanges();
        }
    }
}
