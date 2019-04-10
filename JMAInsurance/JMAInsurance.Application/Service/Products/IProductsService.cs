using JMAInsurance.Models.Dto;

namespace JMAInsurance.Application.Service.Products
{
    public interface IProductsService
    {
        void Create(ProductsDto productsDto);
        void Update(ProductsDto productsDto);
    }
}
