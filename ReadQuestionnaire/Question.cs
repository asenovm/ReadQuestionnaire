using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Read
{
    public class Question
    {
        private const char ITEM_SEPARATOR = '\t';

        public string title;

        public String possibleAnswers;

        public string header;

        public string value;

        public QuestionType type;

        public AnswerType answerType;

        public bool Last { get; set; }

        public bool hasOpenOption;

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

        public LinkedList<Option> GetOptions()
        {
            LinkedList<Option> result = new LinkedList<Option>();
            if (header != null)
            {
                string[] headers = header.Split(ITEM_SEPARATOR);
                string[] values = value == null ? null : value.Split(ITEM_SEPARATOR);
                for (int i = 0; i < headers.Length; ++i)
                {
                    Option option = new Option(headers[i], values == null ? 0 : int.Parse(values[i]));
                    result.AddLast(option);
                }
            }

            return result;
        }

    }
}
