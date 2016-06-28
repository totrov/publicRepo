using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL.Models;

namespace TestExercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var ctx = new Context())
            {
                ViewBag.Products = ctx.Products.ToList();
            }
            return View();
        }

        public string GetClientsJSON(int pageNumber, int clientsPerPage)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new List<Client> { new Client { Fio = "sdfc" } });
        }
    }
}