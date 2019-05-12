﻿using System;
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
    public class OrdersController : Controller
    {


        public ICustomerRepository RepoC { get; }
        public ILocationRepository RepoL { get; }

        public OrdersController(ICustomerRepository repo) =>
            RepoC = repo ?? throw new ArgumentNullException(nameof(repo));

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
        [ValidateAntiForgeryToken]




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
