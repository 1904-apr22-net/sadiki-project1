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
    public class CustomerController : Controller
    {


        public ICustomerRepository Repo { get; }

        public CustomerController(ICustomerRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        public ActionResult Index([FromQuery]string search = "")
        {
            IEnumerable<Customer> restaurants = Repo.GetCustomers(search);
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
                    Repo.AddCustomer(customer);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = Repo.GetCustomerById(id);
            var viewModel = new CustomerViewModel
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [BindNever]IFormCollection collection)
        {
            try
            {
                Repo.DeleteCustomer(id);
                Repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
