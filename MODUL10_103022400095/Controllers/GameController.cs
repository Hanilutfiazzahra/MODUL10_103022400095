using Microsoft.AspNetCore.Mvc;
using MODUL10_103022400095.Models;

namespace MODUL10_103022400095.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly List<Game> _games;

        public GameController()
        {
            _games = new List<Game>
            {
                new Game { Id = 1, Name = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Platform = new List<string> { "PC" }, Rating = 8.5, Mode = new List<string> { "Multiplayer" }, IsOnline = true, Harga = 0 },
                new Game { Id = 2, Name = "GTA V", Developer = "Rockstar Games", TahunRilis = 2013, Genre = "Open Worls", Platform = new List<string> { "PC", "PS4", "PS5", "Xbox" }, Rating = 9.5, Mode = new List<string> { "Singleplayer", "Multiplayer" }, IsOnline = true, Harga = 300000 },
                new Game { Id = 3, Name = "The Witcher 3", Developer = "CD Projekt Red", TahunRilis = 2015, Genre = "RPG", Platform = new List<string> { "PC", "PS4", "PS5", "Xbox", "Switch" }, Rating = 9.7, Mode = new List<string> { "Singleplayer"}, IsOnline = false, Harga = 250000 },
                new Game { Id = 4, Name = "Minecraft", Developer = "Mojang Studios", TahunRilis = 2011, Genre = "Sandbox", Platform = new List<string> { "PC", "PS4", "PS5", "Xbox", "Switch" }, Rating = 9.0, Mode = new List<string> { "Singleplayer", "Multiplayer" }, IsOnline = true, Harga = 200000 },
                new Game { Id = 5, Name = "Among Us", Developer = "Innersloth", TahunRilis = 2018, Genre = "Party", Platform = new List<string> { "PC", "Mobile" }, Rating = 8.0, Mode = new List<string> { "Multiplayer" }, IsOnline = true, Harga = 50000 }
            };
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAllGames()
        {
            return Ok(_games);
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGameById(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public ActionResult CreateGame([FromBody]Game game)
        {
            _games.Add(game);
            return Ok(game);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, Game updatedGame)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            game.Name = updatedGame.Name;
            game.Developer = updatedGame.Developer;
            game.TahunRilis = updatedGame.TahunRilis;
            game.Genre = updatedGame.Genre;
            game.Platform = updatedGame.Platform;
            game.Rating = updatedGame.Rating;
            game.Mode = updatedGame.Mode;
            game.IsOnline = updatedGame.IsOnline;
            game.Harga = updatedGame.Harga;
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            _games.Remove(game);
            return NoContent();
        }
    }
}
