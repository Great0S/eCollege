using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eCollege.Data;

namespace eCollege.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UCMSContext _context;

        public EmployeesController(UCMSContext context)
        {
            _context = context;    
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var uCMSContext = _context.Employees.Include(e => e.DepartmentNavigation).Include(e => e.JobNavigation);
            return View(await uCMSContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees.SingleOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["Department"] = new SelectList(_context.Departments, "Name", "Name");
            ViewData["Job"] = new SelectList(_context.Jobs, "Name", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,Department,Email,Job,Name,Password,Phone,Username")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Department"] = new SelectList(_context.Departments, "Name", "Name", employees.Department);
            ViewData["Job"] = new SelectList(_context.Jobs, "Name", "Name", employees.Job);
            return View(employees);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees.SingleOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }
            ViewData["Department"] = new SelectList(_context.Departments, "Name", "Name", employees.Department);
            ViewData["Job"] = new SelectList(_context.Jobs, "Name", "Name", employees.Job);
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Address,Department,Email,Job,Name,Password,Phone,Username")] Employees employees)
        {
            if (id != employees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["Department"] = new SelectList(_context.Departments, "Name", "Name", employees.Department);
            ViewData["Job"] = new SelectList(_context.Jobs, "Name", "Name", employees.Job);
            return View(employees);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees.SingleOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employees = await _context.Employees.SingleOrDefaultAsync(m => m.Id == id);
            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeesExists(string id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
