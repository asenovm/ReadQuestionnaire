using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Read
{
    public class Questionnaire
    {

        private const string QUESTIONS_FILE = "questions.dat";

        private QuestionReader reader;

        public Questionnaire()
        {
            reader = new QuestionReader(QUESTIONS_FILE);
        }

        public Question GetCurrentQuestion()
        {
            return reader.GetCurrentQuestion();
        }

        public Question GetNextQuestion()
        {
            return reader.GetNextQuestion();
        }

        public bool HasNextQuestion()
        {
            return reader.HasNextQuestion();
        }
    }
}
