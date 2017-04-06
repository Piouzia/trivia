using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    class QuestionStack
    {
        public string Type { get; private set; }
        readonly LinkedList<string> _questionsList;
        public QuestionStack(string type)
        {
            Type = type;
            _questionsList = new LinkedList<string>();

        }

        public void Add(int i)
        {
            _questionsList.AddLast(Type + " Question " + i);
        }

        public void PickQuestion()
        {
            Console.WriteLine(_questionsList.First());
            _questionsList.RemoveFirst();
        }

    }
}
