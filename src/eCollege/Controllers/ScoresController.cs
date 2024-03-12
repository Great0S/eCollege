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
    public class ScoresController : Controller
    {
        private readonly UCMSContext _context;

        public ScoresController(UCMSContext context)
        {
            _context = context;    
        }

        // GET: Scores
        public async Task<IActionResult> Index()
        {
            var uCMSContext = _context.Score.Include(s => s.Reg).Include(s => s.Sub);
            return View(await uCMSContext.ToListAsync());
        }

        public async Task<IActionResult> StudentIndex()
        {
            var uCMSContext = _context.Score.Include(s => s.Reg).Include(s => s.Sub);
            return View(await uCMSContext.ToListAsync());
        }

        // GET: Scores/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = _context.Score.FromSql("SELECT * from score");
            results.ToListAsync();
            
            
            return View(results);
        }

        // GET: Scores/Create
        public IActionResult Create()
        {
            ViewData["RegId"] = new SelectList(_context.Registeration, "RegisterId", "RegisterId");
            ViewData["SubId"] = new SelectList(_context.Subjects, "Name", "Name");
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grade,Term_Grade,Hours,RegId,Semester,SubId")] Score score)
        {
            if (ModelState.IsValid)
            {
                _context.Add(score);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["RegId"] = new SelectList(_context.Registeration, "RegisterId", "RegisterId", score.RegId);
            ViewData["SubId"] = new SelectList(_context.Subjects, "Name", "Name", score.SubId);
            return View(score);
        }

        // GET: Scores/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.Score.SingleOrDefaultAsync(m => m.Id == id);
            if (score == null)
            {
                return NotFound();
            }
            ViewData["RegId"] = new SelectList(_context.Registeration, "RegisterId", "RegisterId", score.RegId);
            ViewData["SubId"] = new SelectList(_context.Subjects, "Name", "Name", score.SubId);
            return View(score);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Grade,Term_Grade,Hours,RegId,Semester,SubId")] Score score)
        {
            if (id != score.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(score);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScoreExists(score.Id))
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
            ViewData["RegId"] = new SelectList(_context.Registeration, "RegisterId", "RegisterId", score.RegId);
            ViewData["SubId"] = new SelectList(_context.Subjects, "Name", "Name", score.SubId);
            return View(score);
        }

        // GET: Scores/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var score = await _context.Score.SingleOrDefaultAsync(m => m.Id == id);
            if (score == null)
            {
                return NotFound();
            }

            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var score = await _context.Score.SingleOrDefaultAsync(m => m.Id == id);
            _context.Score.Remove(score);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ScoreExists(string id)
        {
            return _context.Score.Any(e => e.Id == id);
        }
    }
}
