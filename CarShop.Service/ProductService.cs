﻿using CarShop.Data;
using CarShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Service
{
    public interface IProductService
    {
        void Insert(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        void Delete(Guid id);
        Product Find(Guid id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllByName(string name);
        IEnumerable<Product> Search(string name);
    }
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }

        public void Delete(Product entity)
        {
            productRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var product = productRepository.Find(id);
            if (product != null)
            {
                this.Delete(product);
            }
        }
        public Product Find(Guid id)
        {
            return productRepository.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public IEnumerable<Product> GetAllByName(string name)
        {
            return productRepository.GetAll(w => w.Name.Contains(name));
        }

        public void Insert(Product entity)
        {
            productRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Product> Search(string name)
        {
            return productRepository.GetAll(e => e.Name.Contains(name));
        }

        public void Update(Product entity)
        {
            var product = productRepository.Find(entity.Id);
            product.Name = entity.Name;
            product.Description = entity.Description;
            product.Photo = entity.Photo;
            product.CategoryId = entity.CategoryId;
            productRepository.Update(product);
            unitOfWork.SaveChanges();
        }
    }
}
