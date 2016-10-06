using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fantasy_Football.Data;
using Fantasy_Football.Models;
using Microsoft.AspNetCore.Identity;

namespace Fantasy_Football.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public TeamsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Team.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .Include(t => t.PlayersTeams).ThenInclude(pt => pt.Player)
                .Include(t => t.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            ViewData["Players"] = new SelectList(_context.Player.OrderBy(player => player.Name), "Id", "Name");
            ViewData["CurrentTeamId"] = id;
            Console.WriteLine(id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            ViewData["LeagueId"] = new SelectList(_context.League, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
            return View();
        }

        // POST: Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LeagueId,UserId,Name")] Team team)
        {

            if (ModelState.IsValid)
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.Id == Request.Form["User.Id"]);
                var league = await _context.League.FirstOrDefaultAsync(l => l.Id == int.Parse(Request.Form["LeagueId"]));
                team.User = user;
                _context.Add(team);
                _context.Entry(league).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["LeagueId"] = new SelectList(_context.League, "Id", "Name", team.LeagueId);
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.SingleOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,Name")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
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
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.SingleOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team.Include(t => t.PlayersTeams).SingleOrDefaultAsync(m => m.Id == id);
            _context.Team.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.Id == id);
        }
        [HttpPost]
        public async Task<Player> Assign(int PlayerId, int TeamId)
        {
            var team = await _context.Team.FirstOrDefaultAsync(t => t.Id == TeamId);
            var player = await _context.Player.FirstOrDefaultAsync(p => p.Id == PlayerId);
            PlayersTeams newPlayersTeams = new Models.PlayersTeams { Player = player, Team = team };
            _context.Entry(team).State = EntityState.Modified;
            _context.Entry(player).State = EntityState.Modified;
            _context.Add(newPlayersTeams);
            await _context.SaveChangesAsync();
            return player;


        } 
    }
}
