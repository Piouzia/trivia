using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    class Questions
    {
        QuestionStack popQuestions;
        QuestionStack scienceQuestions;
        QuestionStack sportsQuestions;
        QuestionStack rockQuestions;

        public Questions()
        {
            popQuestions = new QuestionStack("Pop");
            scienceQuestions = new QuestionStack("Science");
            sportsQuestions = new QuestionStack("Sports");
            rockQuestions = new QuestionStack("Rock");
        }

        public void GenerateQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                popQuestions.Add(i);
                scienceQuestions.Add(i);
                sportsQuestions.Add(i);
                rockQuestions.Add(i);
            }
        }

        public void AskQuestion(String type)
        {
            if (type == "Pop")
            {
                popQuestions.PickQuestion();
            }
            if (type == "Science")
            {
                scienceQuestions.PickQuestion();
            }
            if (type == "Sports")
            {
                sportsQuestions.PickQuestion();
            }
            if (type == "Rock")
            {
                rockQuestions.PickQuestion();
            }
        }
    }
}
