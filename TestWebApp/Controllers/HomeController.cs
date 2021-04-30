using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private DataAppContext db;
        public HomeController(DataAppContext context)
        {
            db = context;
        }
        public IActionResult Index() 
        {
            return View();
        }        

        public IActionResult DisplayEmployeesList()
        {
            return new JsonResult(db.Employees.ToList());
        }
        public IActionResult DisplayProfessionsList()
        {
            return new JsonResult(db.Professions.ToList());
        }


        public async Task<IActionResult> Add()
        {
            List<Professions> ProfessionsList = await db.Professions.ToListAsync();
            return View(new EmployeeView(new Employees(), ProfessionsList));
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeView employeeView)
        {
            Employees employee = employeeView.Employees;
            if (employee != null)
            {
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
            
        }


        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> EmployeeToDelete(int? id)
        {
            if (id != null)
            {
                Employees employee = await db.Employees.FirstOrDefaultAsync(p => p.Id == id);
                if (employee != null)
                    return View(employee);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Employees employee = new Employees { Id = id.Value };
                db.Entry(employee).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Employees employee = await db.Employees.FirstOrDefaultAsync(p => p.Id == id);
                List<Professions> ProfessionsList = await db.Professions.ToListAsync();
                if (employee != null)
                return View(new EmployeeView(employee.Id, employee, ProfessionsList));
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeView employeeView)
        {
            Employees employee = employeeView.Employees;
            employee.Id = employeeView.Id;
            db.Employees.Update(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
