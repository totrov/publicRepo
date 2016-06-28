using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Models;
using Newtonsoft.Json;

namespace TestExercise.Controllers
{
    public class HomeController : Controller
    {
        private Context _ctx = new Context();
        public ActionResult Index()
        {
            ViewBag.Products = _ctx.Products.ToList();
            return View();
        }

        public string GetClientsJSON(int pageNumber, int clientsPerPage)
        {
            var clientsCount = _ctx.Clients.Count();
            var pageCount = clientsCount / clientsPerPage + (clientsCount % clientsPerPage == 0 ? 0 : 1);
            var clientsViewModel = _ctx.Clients.OrderBy(client => client.Fio).Select(client => new
            {
                fio = client.Fio,
                orderSum = client.Orders.Sum(order =>
                    order.OrderUnit.Sum(orderUnit => orderUnit.Count * orderUnit.Product.Price))
            }).Skip((pageNumber - 1) * clientsPerPage).Take(clientsPerPage).ToArray();

            return JsonConvert.SerializeObject(new { pageCount = pageCount, clientsViewModel = clientsViewModel });
        }

        private void AddClientOrderStub(string clientFio)
        {
            _ctx.Clients.Add(new Client
            {
                Fio = clientFio,
                Orders =
                    new List<Order>
                    {
                        new Order {OrderUnit = new List<OrderUnit> {new OrderUnit {ProductId = 1, Count = 3}}}
                    }
            });
            _ctx.SaveChanges();
        }
        public HttpStatusCodeResult CreateClient(Client client)
        {
            _ctx.Clients.Add(client);
            _ctx.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}