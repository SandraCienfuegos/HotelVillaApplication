using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public abstract class CultureController : Controller
    {
        private string _language;

        protected string Language =>
            _language ??= Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
    }
}