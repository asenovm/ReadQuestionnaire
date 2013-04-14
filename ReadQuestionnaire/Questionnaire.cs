using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Read
{
    public class Questionnaire
    {

        private QuestionReader reader;

        private string questionsFilePath;

        public Questionnaire(string questionsFilePath)
        {
            reader = new QuestionReader(questionsFilePath);
            this.questionsFilePath = questionsFilePath;
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

        public bool IsLastQuestionnaire()
        {
            return questionsFilePath.Contains("traits");
        }
    }
}
