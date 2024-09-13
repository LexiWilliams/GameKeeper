using GameKeeper.Web.Data;
using GameKeeper.Web.Models.Entities;
using GameKeeper.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameKeeper.Web.Controllers
{
    public class RecordController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public RecordController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecordViewModel model)
        {
            var genre = new GameRecord 
            { 
                Game = model.Game, 
                PlayerRecords = model.PlayerRecords
            };

            await dbContext.AddAsync(genre);

            //save changes to db
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {

            var records = await dbContext.GameRecords.ToListAsync();

            return View(records);
        }


    }
}
