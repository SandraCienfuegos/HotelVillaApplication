using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CultureRouteAttribute : RouteAttribute
    {
        public CultureRouteAttribute(string template) : base($"{{culture}}/{template}")
        {
        }
    }
}