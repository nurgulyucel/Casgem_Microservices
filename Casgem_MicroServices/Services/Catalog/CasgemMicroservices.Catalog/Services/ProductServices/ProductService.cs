using AutoMapper;
using Casgem_MicroServices.Shared.Dtos;
using CasgemMicroservices.Catalog.Dtos.ProductDtos;
using CasgemMicroservices.Catalog.Models;
using CasgemMicroservices.Catalog.Setting.Abstract;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using MongoDB.Driver;

namespace CasgemMicroservices.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Products> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client=new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Products>(databaseSettings.ProductCollectionName);
            _categoryCollection=database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<CreateProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            var values=_mapper.Map<Products>(createProductDto);
            await _productCollection.InsertOneAsync(values);
            return Response<CreateProductDto>.Success(_mapper.Map<CreateProductDto>(values),200);
        }

        public async Task<Response<NoContent>> DeleteProductAsync(string id)
        {
            var value=await _productCollection.DeleteOneAsync(id);
            if(value.DeletedCount> 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Silinecek ürün bulunamadı!", 404);
            }
            
        }

        public async Task<Response<ResultProductDtos>> GetProductByIdAsync(string id)
        {
            var values=await _productCollection.Find<Products>(x=>x.ProductID==id).FirstOrDefaultAsync();
            if (values == null)
            {
                return Response<ResultProductDtos>.Fail("Böyle bir ID bulunamadı",404);
            }
            else
            {
                return Response<ResultProductDtos>.Success(_mapper.Map<ResultProductDtos>(values), 200);
            }

        }

        public async Task<Response<List<ResultProductDtos>>> GetProductListAsync()
        {
            var values=await _productCollection.Find(x=>true).ToListAsync();
            return Response<List<ResultProductDtos>>.Success(_mapper.Map<List<ResultProductDtos>>(values),200);
        }

        public async Task<Response<List<ResultProductDtos>>> GetProductListWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            if(values.Any())
            {
                foreach(var item in values)
                {
                    item.Category=await _categoryCollection.Find<Category>(x=>x.CategoryID==item.CategoryID).FirstOrDefaultAsync();
                }
            }
            else
            {
                values=new List<Products>();
            }
            return Response<List<ResultProductDtos>>.Success(_mapper.Map<List<ResultProductDtos>>(values),200);
        }

        public async Task<Response<UpdateProductDto>> UpdateProductAsync(UpdateProductDto updateproductDto)
        {
            var value = _mapper.Map<Products>(updateproductDto);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.ProductID== updateproductDto.ProductID, value);
            if (result == null)
            {
                return Response<UpdateProductDto>.Fail("Güncellenecek Veri Bulunamadı", 404);
            }
            else
            {
                return Response<UpdateProductDto>.Success(204);
            }

        }
    }
}
