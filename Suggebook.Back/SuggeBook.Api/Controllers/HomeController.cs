using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuggeBook.Api.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        public JsonResult Home (int? userId)
        {
            /// TODO : si le userId est renseigné, on lui récupère ses suggestions
            /// Sinon, on le redirige vers la page de connexion
            /// TODO : mettre en place une couche business
            return null;
        }
    }
}
