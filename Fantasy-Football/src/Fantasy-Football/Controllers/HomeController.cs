using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fantasy_Football.Models;
using Fantasy_Football.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fantasy_Football.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var games =  _context.NflGames.Where(game => game.Week == "4");
            List<NflGame> gameList = new List<NflGame>();
            foreach(var game in games)
            {
                gameList.Add(game);
            }
            return View(gameList);
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
        public IActionResult Admin()
        {
            return View();
        }
        public async Task<IActionResult> UpdateDatabase()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [NflGames]");
            //var players = Player.GetPlayers();
            var games = NflGame.GetGames();
            //foreach (var player in players)
            //{
            //    _context.Player.Add(player);
            //}
            foreach (var game in games)
            {
                _context.NflGames.Add(game);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
