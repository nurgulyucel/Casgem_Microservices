using Casgem_MicroServices.Shared.Dtos;
using CasgemMicroservices.Catalog.Dtos.CategoryDtos;
using CasgemMicroservices.Catalog.Dtos.ProductDtos;

namespace CasgemMicroservices.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDtos>>> GetProductListAsync();
        Task<Response<ResultProductDtos>> GetProductByIdAsync(string id);
        Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto createProductDto);
        Task<Response<UpdateProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<Response<NoContent>> DeleteProductAsync(string id);
        Task<Response<List<ResultProductDtos>>> GetProductListWithCategoryAsync();
    }
}
