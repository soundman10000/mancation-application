using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Game
{
    public class BeerPong
    {
        private Stopwatch _timer;

        public BeerPong(
            Guid id,
            Guid team1,
            Guid team2)
        {
            this.Id = id;
            this.Team1 = team1;
            this.Team2 = team2;
            this.Started = false;
            this.Scores = new Dictionary<Guid, int>();
            this._timer = new Stopwatch();
        }

        public void StartGame()
        {
            this.Started = true;
            this.Scores.Add(this.Team1, 0);
            this.Scores.Add(this.Team2, 0);
            this._timer.Start();;
        }

        public void Score(Guid teamId, int score)
        {
            if (!this.Started)
            {
                throw new Exception(@"Cannot score to a game that has not been started.");
            }

            this.Scores[teamId] =+ score;
        }

        public void EndGame()
        {
            this._timer.Stop();
        }

        public string Elapsed => (this._timer.Elapsed.Milliseconds).ToString();
        public bool Started { get; private set; }
        public Guid Id { get; set; }
        public Guid Team1 { get; }
        public Guid Team2 { get; }
        public Dictionary<Guid, int> Scores { get; }
    }
}
