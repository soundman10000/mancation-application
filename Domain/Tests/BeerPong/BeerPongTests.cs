using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests.BeerPong
{
    [TestFixture]
    public class BeerPongTests
    {
        [Test]
        public void ScoreWorks()
        {
            var team1 = Guid.NewGuid();
            var team2 = Guid.NewGuid();
            const int score = 1;

            var beerPong = new Domain.Game.BeerPong(Guid.NewGuid(), team1, team2);
            beerPong.StartGame();

            beerPong.Score(team1, score);

            Assert.That(beerPong.Scores[team1], Is.EqualTo(score));
            Assert.That(beerPong.Scores[team2], Is.EqualTo(0));

            Thread.Sleep(1000);

            beerPong.EndGame();

            Console.WriteLine($"Game {beerPong.Id} has finshed in {beerPong.Elapsed}");
        }
    }
}
