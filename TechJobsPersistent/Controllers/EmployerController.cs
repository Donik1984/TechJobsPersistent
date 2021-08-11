using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext _dbContext;
        // GET: /<controller>/
        public EmployerController(JobDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Employer> employers = _dbContext.Employers.ToList();

            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();

            return View(addEmployerViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                _dbContext.Employers.Add(newEmployer); // This stages the data
                _dbContext.SaveChanges(); // This actually saves the data in the DB

                return Redirect("/Employer");
            }
            return View("~/Views/Employer/Add.cshtml", addEmployerViewModel);
        }

        //public IActionResult About(int id)
        //{
        //    List<Employer> employers = _dbContext.Employers
        //        .Where(e => e.Id == id)
        //        .Include(e => e.Name)
        //        .Include(e => e.Location)
        //        .ToList();

        //    return View(employers);
        //}

        public IActionResult About(int id)
        {
            Employer thisEmployer = _dbContext.Employers.Find(id);

            return View(thisEmployer);
        }

    }
}
