using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fantasy_Football.Data;
using Fantasy_Football.Models;

namespace Fantasy_Football.Controllers
{
    public class LeaguesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaguesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Leagues
        public async Task<IActionResult> Index()
        {
            return View(await _context.League.ToListAsync());
        }

        // GET: Leagues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.League
                .Include(l => l.Teams)
                .SingleOrDefaultAsync(m => m.Id == id);
            //foreach (var team in league.Teams)
            //{
            //    Console.WriteLine(team.Name);
            //}
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        // GET: Leagues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leagues/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] League league)
        {
            if (ModelState.IsValid)
            {
                _context.Add(league);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(league);
        }

        // GET: Leagues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.League.SingleOrDefaultAsync(m => m.Id == id);
            if (league == null)
            {
                return NotFound();
            }
            return View(league);
        }

        // POST: Leagues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] League league)
        {
            if (id != league.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(league);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeagueExists(league.Id))
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
            return View(league);
        }

        // GET: Leagues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.League.SingleOrDefaultAsync(m => m.Id == id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        // POST: Leagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var league = await _context.League.SingleOrDefaultAsync(m => m.Id == id);
            _context.League.Remove(league);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LeagueExists(int id)
        {
            return _context.League.Any(e => e.Id == id);
        }
    }
}
