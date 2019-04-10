using System;
using JMAInsurance.EntityFramwork.Repository;
using JMAInsurance.Models.Dto;
using JMAInsurance.Entity;
using AutoMapper;

namespace JMAInsurance.Application.Service.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Entity.Products> _repositoryProducts;
        public ProductsService(IRepository<Entity.Products> repositoryProducts)
        {
            _repositoryProducts = repositoryProducts;
        }

        public void Create(ProductsDto productsDto)
        {
            _repositoryProducts.Create(Mapper.Map<Entity.Products>(productsDto));
            _repositoryProducts.Save();
        }
        public void Update(ProductsDto productsDto)
        {
            _repositoryProducts.Update(Mapper.Map<Entity.Products>(productsDto));
            _repositoryProducts.Save();
        }

      
    }
}
