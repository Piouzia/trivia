using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly Players _players;

        readonly Questions _questions = new Questions();

        private bool _isGettingOutOfPenaltyBox;

        public Game(Players p)
        {
            _players = p;
            _questions.GenerateQuestions();
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players.CurrentPlayer.Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players.CurrentPlayer.InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players.CurrentPlayer.Name + " is getting out of the penalty box");
                    _players.CurrentPlayer.Move(roll);

                    Console.WriteLine(_players.CurrentPlayer.Name
                            + "'s new location is "
                            + _players.CurrentPlayer.Place);
                    Console.WriteLine("The category is " + _questions.CurrentCategory(_players.CurrentPlayer.Place % 4));
                    _questions.AskQuestion(_players.CurrentPlayer.Place % 4);
                }
                else
                {
                    Console.WriteLine(_players.CurrentPlayer.Name + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _players.CurrentPlayer.Move(roll);

                Console.WriteLine(_players.CurrentPlayer.Name
                        + "'s new location is "
                        + _players.CurrentPlayer.Place);
                Console.WriteLine("The category is " + _questions.CurrentCategory(_players.CurrentPlayer.Place % 4));
                _questions.AskQuestion(_players.CurrentPlayer.Place % 4);
            }

        }


        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (_players.CurrentPlayer.InPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _players.CurrentPlayer.WinAGoldCoin();

                    winner = _players.DidPlayerWin();
                    _players.NextPlayer();

                    return winner;
                }

                _players.NextPlayer();
                return false;
            }

            Console.WriteLine("Answer was corrent!!!!");
            _players.CurrentPlayer.WinAGoldCoin();

            winner = _players.DidPlayerWin();
            _players.NextPlayer();

            return winner;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players.CurrentPlayer.Name + " was sent to the penalty box");
            _players.CurrentPlayer.GoToPenaltyBox();

            _players.NextPlayer();
            return true;
        }


        

    }
}
