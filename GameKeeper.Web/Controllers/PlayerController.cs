using GameKeeper.Web.Data;
using GameKeeper.Web.Models.Entities;
using GameKeeper.Web.Models.ViewEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameKeeper.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public PlayerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPlayerViewModel model)
        {
            var player = new Player
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            await dbContext.AddAsync(player);

            //save changes to db
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var players = await dbContext.Players.ToListAsync();

            return View(players);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var foundPlayer = await dbContext.Players.FindAsync(id);

            return View(foundPlayer);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Player playerViewModel)
        {
            var foundPlayer = await dbContext.Players.FindAsync(playerViewModel.Id);

            if (foundPlayer != null)
            {
                foundPlayer.FirstName = playerViewModel.FirstName;
                foundPlayer.LastName = playerViewModel.LastName;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Player playerViewModel)
        {
            
            var player = await dbContext.Players
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == playerViewModel.Id);

            if (player != null)
            {
                dbContext.Players.Remove(playerViewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}
