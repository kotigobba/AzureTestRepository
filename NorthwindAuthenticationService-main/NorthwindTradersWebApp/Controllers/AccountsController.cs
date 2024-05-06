
using Microsoft.AspNetCore.Mvc;
using NorthwindModelClassLibrary;
using NorthwindTradersWebApp.Infrastructure;
using System.Buffers.Text;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NorthwindTradersWebApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAuthenticationService _authService; 
        public AccountsController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new AuthenticationRequest();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationRequest model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var authResponse = await _authService.Authenticate(model);
            if(authResponse ==null)
            {
                ModelState.AddModelError("", "Bad Username/Password.");
                return View(model);
            }
            HttpContext.Session.SetString("Token", authResponse.Token);
            HttpContext.Session.SetString("Name", authResponse.FullName);
            HttpContext.Session.SetInt32("UserId", authResponse.UserId);
            var user = await _authService.GetUserModel(authResponse.UserId, authResponse.Token); 
            if(user!=null)
            {
                var str = ConvertData.ObjectToJsonString(user);
                HttpContext.Session.SetString("User", str);
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
