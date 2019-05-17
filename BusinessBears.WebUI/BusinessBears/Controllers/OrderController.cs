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
using BusinessBears.DA;

namespace BusinessBears.Controllers
{
    public class OrdersController : Controller
    {


        public ICustomerRepository RepoC { get; }
        public ILocationRepository RepoL { get; }

        public IProductRepository RepoP { get; }
        public IOrderRepository RepoO { get; }

        public OrdersController(ICustomerRepository repo, IProductRepository repo2, ILocationRepository repo3, IOrderRepository repo4) {
            RepoC = repo ?? throw new ArgumentNullException(nameof(repo));
        RepoP = repo2 ?? throw new ArgumentNullException(nameof(repo2));
            RepoL = repo3 ?? throw new ArgumentNullException(nameof(repo3));
            RepoO = repo4 ?? throw new ArgumentNullException(nameof(repo4));
        }
        public ActionResult Index([FromQuery]string search = "")
        {
            IEnumerable<Customer> restaurants = RepoC.GetCustomers(search);
            IEnumerable<CustomerViewModel> viewModels = restaurants.Select(x => new CustomerViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            });
            return View(viewModels);


        }

        public ActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName", "LastName")]CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = new Customer
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName
                    };
                    RepoC.AddCustomer(customer);
                    RepoC.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SelectC(int CustomerID) {
            ViewBag.CustomerID = CustomerID;
            ViewBag.CustomerName = RepoC.GetCustomerById(CustomerID).FirstName + " " + RepoC.GetCustomerById(CustomerID).LastName;
            return View();
        }

        [HttpPost]
        public ActionResult SelectT([Bind("CustomerID,BearNumber")]OrderViewModel viewModel)
        {
            ViewBag.CustomerID = viewModel.CustomerID;
            ViewBag.CustomerName = RepoC.GetCustomerById(viewModel.CustomerID).FirstName + " " + RepoC.GetCustomerById(viewModel.CustomerID).LastName;
            ViewBag.BearNumber = viewModel.BearNumber;
            IEnumerable<Training> products = RepoP.GetProducts();
            IEnumerable<ProductViewModel> viewModels = products.Select(x => new ProductViewModel
            {
                Id = x.ID,
                Name = x.Name,
                Price = x.Price
            }).Where(x => x.Name != "Bear");
            return View(viewModels);
        }

        [HttpPost]
        public ActionResult SelectL(List<int> TrainingArray, int CustomerID)
        {
            OrderViewModel viewModel = new OrderViewModel();
            
            Customer c = RepoC.GetCustomerById(CustomerID);
            viewModel.Customer = new CustomerViewModel()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Id = c.Id
            };

            IEnumerable<Location> locations = RepoL.GetLocations();
            ViewBag.locationArray = locations.Select(x => x.ID);
            ViewBag.trainingArray = TrainingArray;
            ViewBag.CustomerID = CustomerID;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Finish(List<int> TrainingArray, int CustomerID, int LocationID)
        {
            IEnumerable<Training> products = RepoP.GetProducts();
            Order viewModel = new Order();
            viewModel.bears = new List<OrderBear>();
            int tester = 0;
            for (int i2 = 0; i2 < TrainingArray.Where(x=>x ==0).Count();i2++)
            {
                OrderBear sbvm = new OrderBear();
                sbvm.upgrades = new List<TrainingContainer>();
                while (TrainingArray[tester] !=0)
                {
                    var p = Mapper.Map(products.First(x => x.ID == TrainingArray[tester]));
                    TrainingContainer st = new TrainingContainer()
                    {
                        Product = Mapper.Map(p)
                    };
                    ;
                    sbvm.AddTraining(st);
                    tester++;
                }
                viewModel.AddBear(sbvm);
                tester++;

            }
            
            Customer c = RepoC.GetCustomerById(CustomerID);
            viewModel.CustomerID = c.Id;
 


            Location selectedlocation = RepoL.GetLocationById(LocationID);
            Order finishedorder = viewModel;
            
          
            selectedlocation.ProcessOrder(finishedorder);
            finishedorder.Location = selectedlocation;
            RepoL.UpdateLocation(selectedlocation);
            RepoO.AddOrder(finishedorder);
            RepoL.Save();
            RepoO.Save();
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
