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
        public async Task<IActionResult> Add()
        {
            var record = new AddRecordViewModel
            {
                GameList = await dbContext.Games.ToListAsync(),
                PlayerList = await dbContext.Players.ToListAsync()
            };
           
            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecordViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {

                var playerRecords = new List<PlayerRecord>();

                for (var i = 0; i < model.PlayersToRecord.Count; i++)
                {
                    PlayerRecord r = new PlayerRecord()
                    {
                        Player = model.PlayerList[i],
                        Won = model.WinnerBoolList[i]

                    };
                }
                var gameRecord = new GameRecord
                {
                    Game = model.GameToRecord,
                    PlayerRecords = playerRecords
                };

                await dbContext.AddAsync(gameRecord);

                //save changes to db
                await dbContext.SaveChangesAsync();
            }

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
