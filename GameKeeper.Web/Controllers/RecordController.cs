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
            var t = await dbContext.Games.ToListAsync();
            var t2 = await dbContext.Players.ToListAsync();
            var record = new AddRecordViewModel
            {
                GameList = t,
                PlayerList = t2
            };
           
            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecordViewModel model)
        {
            if (ModelState.IsValid && model.PlayersToRecord != null && model.GameToRecord != null)
            {

                var playerRecords = new List<PlayerRecord>();

                for (var i = 0; i < model.PlayersToRecord.Count; i++)
                {
                    PlayerRecord r = new PlayerRecord()
                    {
                        //Player = model.PlayersToRecord[i],
                        PlayerId = model.PlayersToRecord[i].Id

                    };
                    Console.WriteLine("added player");

                    if (model.WinnerPlayerList != null)
                    {


                        if (model.WinnerPlayerList.Any(x => x.Id == r.PlayerId))
                        {
                            r.Won = true;
                            Console.WriteLine("won");
                        }
                        else
                        {
                            r.Won = false;
                            Console.WriteLine("lost");
                        }
                    }
                    playerRecords.Add(r);
                }

                var gameRecord = new GameRecord
                {

                    GameId = model.GameToRecord.Id,
                    //Game = model.GameToRecord,
                    PlayerRecords = playerRecords
                };
               
                   await dbContext.AddAsync(gameRecord);

                    //save changes to db
                    await dbContext.SaveChangesAsync();

                

                return RedirectToAction("List");

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
