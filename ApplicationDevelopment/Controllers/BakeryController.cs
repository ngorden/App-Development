using ApplicationDevelopment.DAL;
using ApplicationDevelopment.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApplicationDevelopment.Controllers
{
    public class BakeryController : Controller
    {
        private readonly BakeryContext db = new BakeryContext();

        // GET: Bakery
        public ActionResult Index()
        {
            return View();
        }

        // GET: Browse
        public ActionResult Browse()
        {
            return View(db.Products.ToList());
        }

        // GET: Order
        [HttpGet]
        public ActionResult Order()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OrderProduct(Guid id)
        {
            var model = (from p in db.Products
                         where p.Id == id
                         select p).Single();
            return View(model);
        }
        // POST: Order
        [HttpPost]
        public async Task<ActionResult> Order(String product, int quantity, Order model)
        {
            var orderModel = new Order
            { Name = product };

            for (int i = 0; i < quantity; i++)
            {
                db.Orders.Add(orderModel);
            }
            await db.SaveChangesAsync();

            return RedirectToAction("RecentOrders");
        }

        // GET: RecentOrders
        public ActionResult RecentOrders()
        {
            return View(db.Orders.ToList());
        }

        // GET: Request
        public ActionResult RequestProduct()
        {
            return View();
        }
        // POST: Request
        [HttpPost]
        public async Task<ActionResult> RequestProduct(Request model)
        {
            db.Requests.Add(model);
            await db.SaveChangesAsync();
            return RedirectToAction("Browse");
        }
    }
}
