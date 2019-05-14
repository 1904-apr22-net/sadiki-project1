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
            IEnumerable<Training> products = RepoP.GetProducts();
            OrderViewModel viewModel = new OrderViewModel();
            viewModel.SoldBears = new List<SoldBearsViewModel>();
            foreach (int i in TrainingArray)
            {
                SoldBearsViewModel sbvm = new SoldBearsViewModel();
                sbvm.SoldTraining = new List<SoldTrainingViewModel>();
                if (i == 0)
                {
                    viewModel.SoldBears.Append(sbvm);
                }
                else if (i == -1)
                {
                    viewModel.SoldBears.Append(sbvm);
                }
                else
                {
                    var p = Mapper.Map(products.First(x => x.ID == i));
                    SoldTrainingViewModel st = new SoldTrainingViewModel();
                    
                    st.Product = new ProductViewModel
                        {
                            Id = p.ProductId,
                            Name = p.ProductName,
                            Price = Convert.ToDouble(p.DefPrice)
                        }
                    ;
                    sbvm.SoldTraining = new List<SoldTrainingViewModel>() { st };
                };
            }
            Customer c = RepoC.GetCustomerById(CustomerID);
            viewModel.Customer = new CustomerViewModel()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Id = c.Id
            };

            IEnumerable<Location> locations = RepoL.GetLocations();
            ViewBag.locationArray = locations.Select(x => new List<int> { x.ID });
            ViewBag.trainingArray = TrainingArray;
            ViewBag.CustomerID = CustomerID;

            return View(viewModel);
        }

        [HttpPost]
        //public ActionResult Finish(OrderViewModel viewModel, int LocationID)
        public ActionResult Finish(List<int> TrainingArray, int CustomerID, int LocationID)
        {
            IEnumerable<Training> products = RepoP.GetProducts();
            Order viewModel = new Order();
            viewModel.bears = new List<OrderBear>();
            List<OrderBear> test = new List<OrderBear>();
            OrderBear sbvm = new OrderBear();
            sbvm.upgrades = new List<TrainingContainer>();
            TrainingArray.RemoveAt(TrainingArray.Count - 1);
            foreach (int i in TrainingArray)
            {
               
                if (i == 0)
                {
                    test.Add(sbvm);
                }
                else if (i == -1)
                {
                    sbvm.upgrades = new List<TrainingContainer>();
                }
                else
                {
                    var p = Mapper.Map(products.First(x => x.ID == i));
                    TrainingContainer st = new TrainingContainer()
                    {
                        Product = Mapper.Map(p)
                    };
                    ;
                    sbvm.AddTraining(st);
                };
            }
            viewModel.bears = test;
            Customer c = RepoC.GetCustomerById(CustomerID);
            viewModel.Customer = new Customer();
            viewModel.Customer.FirstName = c.FirstName;
            viewModel.Customer.LastName = c.LastName;


            Location selectedlocation = RepoL.GetLocationById(LocationID);
            Order finishedorder = viewModel;
            
            //Order finishedorder = new Order
            //{
            //    ID = viewModel.ID,
            //    Price = viewModel.Price,
            //    Customer = new Customer()
            //    {
            //        FirstName = viewModel.Customer.FirstName,
            //        LastName = viewModel.Customer.LastName
            //    },
            //    LocationID = LocationID,
            //    Location = selectedlocation,
            //    CustomerID = viewModel.CustomerID,
            //    bears = viewModel.SoldBears.Select(y => new OrderBear()
            //    {
            //        ID = y.ID,
            //        upgrades = y.SoldTraining.Select(z => new TrainingContainer()
            //        {
            //            ID = z.Id,
            //            Product = new Training()
            //            {
            //                Name = z.Product.Name,
            //                Price = z.Product.Price
            //            }
            //        }).ToList()
            //    }).ToList()
            //};
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
