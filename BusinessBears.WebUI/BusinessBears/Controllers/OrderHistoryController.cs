using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessBears.Models;
using BusinessBears.Library.Interfaces;
using BusinessBears.WebUI.Models;
using BusinessBears.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BusinessBears.Controllers
{
    public class OrderHistoryController : Controller
    {


        public IOrderRepository Repo { get; }

        public OrderHistoryController(IOrderRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        public ActionResult Index([FromQuery]string search = "", [FromQuery]string searchby = "", [FromQuery]string orderby = "")
        {
            IEnumerable<Order> orders;
            orders = Repo.GetOrders();
            if (search != null)
            {
                orders = Repo.GetOrders(search, searchby, orderby);
            }
            IEnumerable<OrderViewModel> viewModels = orders.Select(x => new OrderViewModel
            {
                ID = x.ID,
                Price = x.Price,
                Customer = new CustomerViewModel()
                {
                    Id = x.Customer.Id,
                    FirstName = x.Customer.FirstName,
                    LastName = x.Customer.LastName
                },
                LocationID = x.LocationID,
                CustomerID = x.CustomerID,
                SoldBears = x.bears.Select(y => new SoldBearsViewModel()
                {
                    ID = y.ID,
                    SoldTraining = y.upgrades.Select(z => new SoldTrainingViewModel()
                    {
                        Id = z.ID,
                        Product = new ProductViewModel()
                        {
                            Name = z.Product.Name,
                            Price = z.Product.Price
                        }
                    }).Where(z => z.Product.Name != "Bear")
                })

            });
            return View(viewModels);


        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind("FirstName", "LastName")]LocationViewModel viewModel)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var location = new Location
        //            {
        //                FirstName = viewModel.FirstName,
        //                LastName = viewModel.LastName
        //            };
        //            Repo.AddLocation(location);
        //            Repo.Save();

        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(viewModel);
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Location/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    Location location = Repo.GetLocationById(id);
        //    var viewModel = new LocationViewModel
        //    {
        //        FirstName = location.FirstName,
        //        LastName = location.LastName
        //    };
        //    return View(viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, [BindNever]IFormCollection collection)
        //{
        //    try
        //    {
        //        Repo.DeleteLocation(id);
        //        Repo.Save();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //} 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
