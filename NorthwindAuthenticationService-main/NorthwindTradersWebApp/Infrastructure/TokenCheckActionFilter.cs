using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NorthwindTradersWebApp.Infrastructure
{
    public class TokenCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Session.GetString("Token"); 
            if(string.IsNullOrEmpty(token))
            {
                context.Result = new ViewResult()
                {
                    ViewName = "Unauthorized"
                };
            }
        }
    }
}
