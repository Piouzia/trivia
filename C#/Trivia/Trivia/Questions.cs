using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    class Questions
    {
        public string Type { get; private set; }
        readonly LinkedList<string> _questionsList;
        public Questions(string type)
        {
            Type = type;
            _questionsList = new LinkedList<string>();

        }

        public void Add(string q)
        {
            _questionsList.AddLast(q);
        }

        public void PickQuestion()
        {
            Console.WriteLine(_questionsList.First());
            _questionsList.RemoveFirst();
        }

    }
}
