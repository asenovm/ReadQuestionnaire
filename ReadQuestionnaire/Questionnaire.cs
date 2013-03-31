using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadQuestionnaire
{
    public class Questionnaire
    {

        private const string QUESTIONS_FILE = "questions.dat";

        private QuestionReader reader;
        
        public Questionnaire() {
            reader = new QuestionReader(QUESTIONS_FILE);
        }

        public Question GetNextQuestion() {
            return reader.GetNextQuestion();
        }

        public bool HasNextQuestion() {
            return reader.HasNextQuestion();
        }
    }
}
