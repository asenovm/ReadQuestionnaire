﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Read
{
    public class QuestionReader
    {
        private const int QUESTION_ENCODING = 1251;

        private LinkedList<Question> questions;

        private int readQuestions;

        public QuestionReader(string filePath)
        {
            questions = new LinkedList<Question>();

            StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding(QUESTION_ENCODING));
            string currentLine = null;
            while ((currentLine = reader.ReadLine()) != null)
            {
                Question question = JsonConvert.DeserializeObject<Question>(currentLine);
                questions.AddLast(question);
            }
            questions.Last.Value.Last = true;
            reader.Close();
        }

        public Question GetCurrentQuestion()
        {
            return questions.ElementAt(readQuestions - 1);
        }

        public Question GetNextQuestion()
        {
            return questions.ElementAt(readQuestions++);
        }

        public bool HasNextQuestion()
        {
            return readQuestions < questions.Count;
        }

    }
}
