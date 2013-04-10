using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadQuestionnaire
{
    public class Question
    {
        private const char ITEM_SEPARATOR = '\t';

        public string title;

        public string possibleAnswers;

        public string header;

        public QuestionType type;

        public AnswerType answerType;

        public LinkedList<string> GetPossibleAnswers()
        {
            LinkedList<string> result = new LinkedList<string>();
            if (possibleAnswers != null)
            {
                string[] answers = possibleAnswers.Split(ITEM_SEPARATOR);
                foreach (string answer in answers)
                {
                    result.AddLast(answer);
                }
            }
            return result;
        }

        public LinkedList<string> GetHeaders()
        {
            LinkedList<string> result = new LinkedList<string>();
            if (header != null)
            {
                string[] headers = header.Split(ITEM_SEPARATOR);
                foreach (string headerItem in headers)
                {
                    result.AddLast(headerItem);
                }
            }
            return result;
        }

    }
}
