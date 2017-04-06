using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    public class Players
    {
        private readonly List<Player> _players = new List<Player>();
        public Player CurrentPlayer { get; private set; }

        public void Add(string playerName)
        {
            Player newPlayer = new Player(playerName);
            if (!_players.Any())
            {
                CurrentPlayer = newPlayer;
            }
            _players.Add(newPlayer);

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
        }

        public void NextPlayer()
        {
            var indexCurrPlayer = _players.IndexOf(CurrentPlayer);
            indexCurrPlayer++;
            if (indexCurrPlayer == _players.Count) indexCurrPlayer = 0;
            CurrentPlayer = _players[indexCurrPlayer];
        }

        public bool DidPlayerWin()
        {
            return CurrentPlayer.IsWinner();
        }
    }
}
