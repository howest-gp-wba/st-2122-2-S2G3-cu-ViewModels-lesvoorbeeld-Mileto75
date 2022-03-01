using System.Collections.Generic;

namespace cu.ViewModels.Lesvoorbeeld.ViewModels
{
    public class GamesGetGamesViewModel
    {
        //keep a list of games
        public IEnumerable<GamesGetGameViewModel> Games { get; set; }
    }
}
