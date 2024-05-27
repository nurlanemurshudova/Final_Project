using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected void AddModelError(Dictionary<string, string> properties)
        {
            ModelState.Clear();
            foreach (var item in properties)
            {
                    ModelState.AddModelError(item.Key, item.Value);
            }
        }
    }
}