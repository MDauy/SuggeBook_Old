using Microsoft.AspNetCore.Mvc;

namespace SuggeBook.Api.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        public JsonResult Home (int? userId)
        {
            return new JsonResult("Hello !");
        }
    }
}
