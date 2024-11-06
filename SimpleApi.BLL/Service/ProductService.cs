using SimpleApi.BLL.Models;
using SimpleApi.BLL.Service.Intrfaces;
using SimpleApi.Domain.Entity;
using SimpleApi.Domain.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.BLL.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Add(ProductModel product)
        {
            Product newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                Price = product.Price
            };
            var result= _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Complete();

            return result.Id;
        }

        public void Delete(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            _unitOfWork.Products.Delete(product);
            _unitOfWork.Complete();
        }

        public List<ProductViewModel> Find(Expression<Func<ProductModel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductViewModel GetById(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            ProductViewModel viewModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock,
                Price = product.Price
            };
            return viewModel;
        }

        public List<ProductViewModel> List(int start, int size)
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();

            var product = _unitOfWork.Products.ListProducts(start, size);
            foreach (var item in product)
            {
                ProductViewModel productViewModel = new ProductViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    QuantityInStock = item.QuantityInStock,
                    Price = item.Price
                };
                productList.Add(productViewModel);
            }
            return productList;
        }

        public int Update(ProductViewModel product)
        {
            Product oldProduct = _unitOfWork.Products.GetById(product.Id);
            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;
            oldProduct.QuantityInStock = product.QuantityInStock;
            oldProduct.Price = product.Price;
            oldProduct.ModifiedDate = DateTime.Now;

            var result =_unitOfWork.Products.Update(oldProduct);
            _unitOfWork.Complete();

            return result.Id;
        }
    }
}
