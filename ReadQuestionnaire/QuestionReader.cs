using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReadQuestionnaire
{
    public class QuestionReader
    {
        private const int QUESTION_ENCODING = 1251;

        private LinkedList<Question> questions;

        private int readQuestions;

        public QuestionReader(string filePath) {
            questions = new LinkedList<Question>();

            StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding(QUESTION_ENCODING));
            string currentLine = null;
            while ((currentLine = reader.ReadLine()) != null) {
                questions.AddLast(new Question(currentLine));
            }
            reader.Close();
        }

        public Question GetNextQuestion() {
            return questions.ElementAt(readQuestions++);
        }

        public bool HasNextQuestion()
        {
            return readQuestions < questions.Count;
        }

    }
}
