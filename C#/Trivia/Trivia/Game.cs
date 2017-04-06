using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly Players _players;
        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() {{0, "Pop"}, {1, "Science"}, {2, "Sports"}, {3, "Rock"}};

        Questions popQuestions = new Questions("Pop");
        Questions scienceQuestions = new Questions("Science");
        Questions sportsQuestions = new Questions("Sports");
        Questions rockQuestions = new Questions("Rock");

        private bool _isGettingOutOfPenaltyBox;

        public Game(Players p)
        {
            _players = p;
            GenerateQuestions();
        }

        private void GenerateQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                popQuestions.Add("Pop Question " + i);
                scienceQuestions.Add(("Science Question " + i));
                sportsQuestions.Add(("Sports Question " + i));
                rockQuestions.Add(CreateRockQuestion(i));
            }
        }

        public string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
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
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
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
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }

        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                popQuestions.PickQuestion();
            }
            if (CurrentCategory() == "Science")
            {
                scienceQuestions.PickQuestion();
            }
            if (CurrentCategory() == "Sports")
            {
                sportsQuestions.PickQuestion();
            }
            if (CurrentCategory() == "Rock")
            {
                rockQuestions.PickQuestion();
            }
        }


        private string CurrentCategory()
        {
            return _categories[_players.CurrentPlayer.Place % 4];
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
