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
    public class TimetablesController : Controller
    {
        private readonly UCMSContext _context;

        public TimetablesController(UCMSContext context)
        {
            _context = context;    
        }

        // GET: Timetables
        public async Task<IActionResult> Index()
        {
            var uCMSContext = _context.Timetable.Include(t => t.Room);
            return View(await uCMSContext.ToListAsync());
        }

        // GET: Timetables/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timetable = await _context.Timetable.SingleOrDefaultAsync(m => m.SchId == id);
            if (timetable == null)
            {
                return NotFound();
            }

            return View(timetable);
        }

        // GET: Timetables/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "RoomName");
            return View();
        }

        // POST: Timetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchId,CourseId,Day,Month,RoomId,Teacher,Time")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timetable);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "RoomName", timetable.RoomId);
            return View(timetable);
        }

        // GET: Timetables/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timetable = await _context.Timetable.SingleOrDefaultAsync(m => m.SchId == id);
            if (timetable == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "RoomName", timetable.RoomId);
            return View(timetable);
        }

        // POST: Timetables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("SchId,CourseId,Day,Month,RoomId,Teacher,Time")] Timetable timetable)
        {
            if (id != timetable.SchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timetable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimetableExists(timetable.SchId))
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
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "RoomName", timetable.RoomId);
            return View(timetable);
        }

        // GET: Timetables/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timetable = await _context.Timetable.SingleOrDefaultAsync(m => m.SchId == id);
            if (timetable == null)
            {
                return NotFound();
            }

            return View(timetable);
        }

        // POST: Timetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var timetable = await _context.Timetable.SingleOrDefaultAsync(m => m.SchId == id);
            _context.Timetable.Remove(timetable);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TimetableExists(decimal id)
        {
            return _context.Timetable.Any(e => e.SchId == id);
        }
    }
}
