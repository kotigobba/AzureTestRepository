using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NorthwindModelClassLibrary;
using NorthwindTradersWebApp.Infrastructure;
using NuGet.Common;

namespace NorthwindTradersWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepositoryAsync<Product> _repositoryAsync;
        private readonly ApiConfigurations _apiConfig;
        public ProductsController(
            IRepositoryAsync<Product> repositoryAsync,
            IOptions<ApiConfigurations> options)
        {
            _repositoryAsync = repositoryAsync;
            _apiConfig = options.Value;
        }

        [TokenCheck]
        public async Task<IActionResult> List()
        {
            //string token = HttpContext.Session.GetString("Token"); 

            /*var model = await ApiHelper.ExecuteHttpGet<List<Product>>(
                url: _apiConfig.ProductUrl!,
                token: token,
                baseUrl: _apiConfig.ProductBaseUrl!);*/

            var model = await _repositoryAsync.GetAll();
            return View(model);
        }

        [TokenCheck]
        public async Task<IActionResult> Details(int id)
        {
            /*var model = await ApiHelper.ExecuteHttpGet<Product>(
                url: $"{_apiConfig.ProductUrl}/{id}",
                token: HttpContext.Session.GetString("Token"),
                baseUrl: _apiConfig.ProductBaseUrl!);*/

            var model = await _repositoryAsync.GetById(id);
            return View(model);
        }
    }
}
