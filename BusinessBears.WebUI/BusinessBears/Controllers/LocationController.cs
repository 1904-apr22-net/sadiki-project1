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
    public class LocationController : Controller
    {


        public ILocationRepository Repo { get; }

        public LocationController(ILocationRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        public ActionResult Index([FromQuery]string search = "")
        {
            IEnumerable<Location> locations = Repo.GetLocations(search);
            IEnumerable<LocationViewModel> viewModels = locations.Select(x => new LocationViewModel
            {
                ID = x.ID,
                Inventory = x.Inventory.Select(y => new InventoryItemViewModel()
                {
                    Id = y.ID,
                    Quantity = y.Quantity,
                    Product = new ProductViewModel ()
                    {
                        Name = y.Product.Name,
                        Id = y.Product.ID

                        
                    }
                }
                ).OrderBy(y => y.Product.Name)
            });
            return View(viewModels);


        }

        public ActionResult EditPlus(int id, int id2)
        {
            // we pass the current values into the Edit view
            // so that the input fields can be pre-populated instead of blank
            // (important for good UX)
            Location x2 = Repo.GetLocationById(id);
            x2.Inventory.First(y => y.ID == id2).Quantity = 69;
            Repo.UpdateLocation(x2);
            Repo.Save();
            IEnumerable < Location > x3 = Repo.GetLocations();
            IEnumerable<LocationViewModel> viewModels = x3.Select(x => new LocationViewModel
            {
                ID = x.ID,
                Inventory = x.Inventory.Select(y => new InventoryItemViewModel()
                {
                    Id = y.ID,
                    Quantity = y.Quantity,
                    Product = new ProductViewModel()
                    {
                        Name = y.Product.Name,
                        Id = y.Product.ID


                    }
                }
                ).OrderBy(y => y.Product.Name)
            });
            return RedirectToAction(nameof(Index));
        }

        public ActionResult EditMinus(int id, int id2)
        {
            // we pass the current values into the Edit view
            // so that the input fields can be pre-populated instead of blank
            // (important for good UX)
            Location x = Repo.GetLocationById(id);
            x.Inventory.First(y => y.Product.ID == id2).Quantity--;
            Repo.UpdateLocation(x);
            var viewModel = new LocationViewModel
            {
                ID = x.ID,
                Inventory = x.Inventory.Select(y => new InventoryItemViewModel()
                {
                    Id = y.ID,
                    Quantity = y.Quantity,
                    Product = new ProductViewModel()
                    {
                        Name = y.Product.Name,
                        Id = y.Product.ID


                    }
                }
                ).OrderBy(y => y.Product.Name)
            };
            return RedirectToAction(nameof(Index));
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
