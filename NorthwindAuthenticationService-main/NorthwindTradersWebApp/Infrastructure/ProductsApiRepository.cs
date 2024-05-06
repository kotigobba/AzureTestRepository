using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NorthwindModelClassLibrary;

namespace NorthwindTradersWebApp.Infrastructure
{
    public class ProductsApiRepository : IRepositoryAsync<Product>
    {
        private readonly ApiConfigurations _apiConfig;
        private readonly UserModel user;
        private readonly string token; 
        public ProductsApiRepository(
            IHttpContextAccessor contextAccessor,
            IOptions<ApiConfigurations> options)
        {
            _apiConfig = options.Value;
            token = contextAccessor.HttpContext.Session.GetString("Token")!;
            var userString = contextAccessor.HttpContext.Session.GetString("User")!;
            user = ConvertData.JsonStringToObject<UserModel>(userString)!;
        }

        

        public Task CreateNew(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = await ApiHelper.ExecuteHttpGet<List<Product>>(
                url: _apiConfig.ProductUrl !, 
                token: token, 
                baseUrl: _apiConfig.ProductBaseUrl !);
            return result;
        }

        public async Task<Product> GetById(int id)
        {
            var result = await ApiHelper.ExecuteHttpGet<Product>(
                url: $"{_apiConfig.ProductUrl}/{id}",
                token: token,
                baseUrl: _apiConfig.ProductBaseUrl!);
            return result;
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
