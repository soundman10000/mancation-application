using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Team;
using Domain.Game;
namespace Service.Service
{
    public class BeerPong : ServiceStack.Service
    {
        public void CreateBeerPongGame(Guid id, Guid team1, Guid team2)
        {
            var beerPongGame = new Domain.Game.BeerPong(id, team1, team2);
        }

        public void StartBeerPongGame(Guid id)
        {
            var beerPongGame = new Domain.Game.BeerPong(id, Guid.Empty, Guid.Empty);

            if (beerPongGame.Started)
            {
                throw new Exception("Beer Pong Game has already been started.");
            }

            beerPongGame.StartGame();
        }

        public void UpdateScore(Guid gameId, Guid teamId, int score)
        {
            var beerPongGame = new Domain.Game.BeerPong(gameId, Guid.Empty, Guid.Empty);
            beerPongGame.Score(teamId, score);
        }
    }
}
