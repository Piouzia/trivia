using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    class Questions
    {
        readonly QuestionStack _popQuestions;
        readonly QuestionStack _scienceQuestions;
        readonly QuestionStack _sportsQuestions;
        readonly QuestionStack _rockQuestions;

        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() { { 0, "Pop" }, { 1, "Science" }, { 2, "Sports" }, { 3, "Rock" } };

        public Questions()
        {
            _popQuestions = new QuestionStack("Pop");
            _scienceQuestions = new QuestionStack("Science");
            _sportsQuestions = new QuestionStack("Sports");
            _rockQuestions = new QuestionStack("Rock");
        }

        public void GenerateQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                _popQuestions.Add(i);
                _scienceQuestions.Add(i);
                _sportsQuestions.Add(i);
                _rockQuestions.Add(i);
            }
        }

        public void AskQuestion(int i)
        {
            if (_categories[i] == "Pop")
            {
                _popQuestions.PickQuestion();
            }
            if (_categories[i] == "Science")
            {
                _scienceQuestions.PickQuestion();
            }
            if (_categories[i] == "Sports")
            {
                _sportsQuestions.PickQuestion();
            }
            if (_categories[i] == "Rock")
            {
                _rockQuestions.PickQuestion();
            }
        }

        public string CurrentCategory(int i)
        {
            return _categories[i];
        }
    }
}
