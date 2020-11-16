namespace OnlineShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Threading.Tasks;


    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
            => this.Ok("hi");
    }
}
