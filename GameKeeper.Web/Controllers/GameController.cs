using GameKeeper.Web.Data;
using GameKeeper.Web.Models.Entities;
using GameKeeper.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameKeeper.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public GameController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGameViewModel model)
        {
            var game = new Game
            {
                Name = model.Name,
                Publisher = model.Publisher
                //,Genres = model.Genres
            };
            await dbContext.AddAsync(game);

            //save changes to db
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var games = await dbContext.Games.ToListAsync();

            return View(games);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var foundGame = await dbContext.Games.FindAsync(id);

            return View(foundGame);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Game gameViewModel)
        {
            var foundGame = await dbContext.Games.FindAsync(gameViewModel.Id);

            if (foundGame != null)
            {
                foundGame.Name = gameViewModel.Name;
                foundGame.Publisher = gameViewModel.Publisher;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Game gameViewModel)
        {

            var foundGame = await dbContext.Games
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == gameViewModel.Id);

            if (foundGame != null)
            {
                dbContext.Games.Remove(gameViewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }

        [HttpGet("{filter}")]
        public async Task<List<Game>> AlLGames()
        {
            //var games = dbContext.List(GamePolicy.ByTitleLike(filter));
            var games = await dbContext.Games.ToListAsync();

            return (games);
        }


    }
}
