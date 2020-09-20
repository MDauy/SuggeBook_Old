using Microsoft.AspNetCore.Mvc;

namespace SuggeBook.Api.Controllers
{
    [Route("api/home")]
    public class HomeController : Controller
    {
        [HttpGet]
        public JsonResult Index ()
        {
            return new JsonResult("Hello !");
        }
    }
}
