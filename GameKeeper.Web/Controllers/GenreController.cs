using GameKeeper.Web.Data;
using GameKeeper.Web.Models.Entities;
using GameKeeper.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameKeeper.Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public GenreController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGenreViewModel model)
        {
            var genre = new Genre
            {
                Name = model.Name
            };
            await dbContext.AddAsync(genre);

            //save changes to db
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var genres = await dbContext.Genres.ToListAsync();

            return View(genres);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var foundGenre = await dbContext.Genres.FindAsync(id);

            return View(foundGenre);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Genre genreViewModel)
        {
            var foundGenre = await dbContext.Genres.FindAsync(genreViewModel.Id);

            if (foundGenre != null)
            {
                foundGenre.Name = genreViewModel.Name;
                //foundGenre.Games = genreViewModel.Games;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Genre genreViewModel)
        {

            var player = await dbContext.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == genreViewModel.Id);

            if (player != null)
            {
                dbContext.Genres.Remove(genreViewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}
