using API.Domain.Models;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public abstract class AuthorizeController : Controller
    {
        private Customer customer;

        protected Customer Customer =>
            customer ??= ((string) Request.HttpContext.Request?.Headers["Authorization"])
                .Replace("Bearer ", string.Empty)
                .ToUser();
    }
}