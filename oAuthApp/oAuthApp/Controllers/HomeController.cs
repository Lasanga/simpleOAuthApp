using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oAuthApp.Ef;
using oAuthApp.Models;

namespace oAuthApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var claims = ((ClaimsIdentity)User.Identity).Claims;
            ViewBag.name = claims.FirstOrDefault(x => x.Type == "name")?.Value;


            var employees = _context.Employees.ToList();

            return View(employees);

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee input)
        {
            var emp = new Employee
            {
                Name = input.Name,  
                Address = input.Address,
                Age = input.Age,
                Salary = input.Salary,
                worktype = input.worktype
            };

            var row = await _context.AddAsync(emp);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
