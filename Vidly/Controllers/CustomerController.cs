using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;

using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();       
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Edit(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customers == null)
                return HttpNotFound();

            var viewmodels = new newviewmodel
            {
                customer = customers,
                MembershipTypes = _context.MembershipType.ToList()

            };
            return View("CustomerForm", viewmodels);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            
            if (!ModelState.IsValid)
            {
                var viewmodel = new newviewmodel
                {
                    customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewmodel);
            } 
                    
            if (customer.CustomerId == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerinDb = _context.Customers.Single(c => c.CustomerId == customer.CustomerId);

                customerinDb.CustomerName = customer.CustomerName;
                customerinDb.birthdate = customer.birthdate;
                customerinDb.MembershipTypeId = customer.MembershipTypeId;
                customerinDb.iscustomersuscribedtonewsletter = customer.iscustomersuscribedtonewsletter;

            }
           // try
            //{
                _context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    Console.WriteLine(e);
            //}
            
                
                return RedirectToAction("CustomerList","Customer");
        }

        public ActionResult CustomerForm()
        {
            var membership = _context.MembershipType.ToList();

            var viewmodels = new newviewmodel()
            {
                MembershipTypes = membership
        };

            return View(viewmodels);
        }

        public ActionResult CustomerList()
        {
            var customer = _context.Customers.Include( c => c.MembershipType).ToList();

            return View(customer);
        }

        
        }

        

    }
