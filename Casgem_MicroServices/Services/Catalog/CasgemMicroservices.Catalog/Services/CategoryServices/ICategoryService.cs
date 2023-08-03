using Casgem_MicroServices.Shared.Dtos;
using CasgemMicroservices.Catalog.Dtos.CategoryDtos;

namespace CasgemMicroservices.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<Response<List<ResultCategoryDto>>> GetCategoryListAsync();
        Task<Response<ResultCategoryDto>> GetCategoryByIdAsync(string id);
        Task<Response<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto category);
        Task<Response<UpdateCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto category);
        Task<Response<NoContent>> DeleteCategoryAsync(string id);

    }
}
