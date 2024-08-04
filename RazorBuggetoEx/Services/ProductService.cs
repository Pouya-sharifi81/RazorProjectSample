using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RazorBuggetoEx.DAL;
using RazorBuggetoEx.DTO;
using RazorBuggetoEx.Models;

namespace RazorBuggetoEx.Services
{
    public class ProductService : IProductService
    {
        private RazorDbContex _contex;

        public ProductService(RazorDbContex contex)
        {
            _contex = contex;
        }

        public int Add(ProductDto product)
        {
           Product model = new Product()
           {
               Name = product.Name,
               Price = product.Price,
               Description = product.Description,
           };

            _contex.products.Add(model);
            _contex.SaveChanges();
            return model.Id;
        }

        public int Delete(int Id)
        {
            _contex.products.Remove(new Models.Product
            {
                Id = Id,
            });
            return _contex.SaveChanges();
        }

        public ProductDto Edit(ProductDto product)
        {
            var entity = _contex.products.Find(product.Id);
            entity.Description = product.Description;
            entity.Name = product.Name;
            entity.Price = product.Price;
            _contex.SaveChanges();
            return product;
        }

        public ProductDto Find(int Id)
        {
            var product = _contex.products.Find(Id);
            return new ProductDto
            {
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
        }

        public List<ProductDto> List()
        {
            var products = _contex.products.OrderByDescending(p => p.Id)
              .Select(p => new ProductDto
              {
                  Description = p.Description,
                  Id = p.Id,
                  Name = p.Name,
                  Price = p.Price
              }).ToList();
            return products;
        }

        public List<ProductDto> Search(string name)
        {
            var products = _contex.products
                 .Where(p => p.Name.Contains(name))
                         .OrderByDescending(p => p.Id)
                    .Select(p => new ProductDto
                    {
                        Description = p.Description,
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price
                    }).ToList();
                    return products;
        }
    }
}
    