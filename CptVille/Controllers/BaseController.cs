        using CptVille.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CptVille.Controllers
{
    public class BaseController : Controller
    {

        private readonly VilleContext _villeContext;
        public BaseController(VilleContext villeContext)
        {
            _villeContext = villeContext;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

    }
}
