using cu.ViewModels.Lesvoorbeeld.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Wba.Oefening.Games.Core;

namespace cu.ViewModels.Lesvoorbeeld.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;

        public GamesController()
        {
            _gameRepository = new GameRepository();
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Our Games!";
            ViewData["Message"] = "Welcome to our cool app!";
            return View();
        }

        public IActionResult GetGames()
        {
            //get the games
            //create the model
            GamesGetGamesViewModel gamesGetGamesViewModel = new GamesGetGamesViewModel();
            gamesGetGamesViewModel.Games = _gameRepository.GetGames()
                .Select(g => new GamesGetGameViewModel {
                    Title = g?.Title,
                    Developer = g?.Developer?.Name,
                    Rating = (int)g?.Rating
                });
            return View(gamesGetGamesViewModel);
            //gamesGetGamesViewModel.Games = new List<GamesGetGameViewModel>();
            //foreach(var game in _gameRepository.GetGames())
            //{
            //    gamesGetGamesViewModel.Games.Add(
            //        new GamesGetGameViewModel
            //        {
            //            Title = game?.Title,
            //            Developer = game?.Developer?.Name,
            //            Rating = (int)game?.Rating
            //        }
            //        );
            //}
            //fill the model
            //pass to the view
        }

        public IActionResult GetGame(int id)
        {
            //get the game
            var game = _gameRepository
                .GetGames()
                .FirstOrDefault(g => g.Id == id);
            //check for null or use coalesence
            //create the model
            GamesGetGameViewModel gamesGetGameViewModel = new GamesGetGameViewModel();
            //fill the model

            gamesGetGameViewModel.Title = game?.Title ?? "<NoTitle>";
            gamesGetGameViewModel.Developer = game?.Developer?.Name ?? "<NoName>";
            gamesGetGameViewModel.Rating = game?.Rating ?? 0;
            //Send to the view
            return View(gamesGetGameViewModel);
        }
    }
}
