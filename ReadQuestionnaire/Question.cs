using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadQuestionnaire
{
    public class Question
    {
        public string title;

        public string possibleAnswers;

        public QuestionType type;

        public Question(string title, QuestionType type) {
            this.title = title;
            this.type = type;
        }

        public LinkedList<string> GetPossibleAnswers() {
            LinkedList<string> result = new LinkedList<string>();
            if (possibleAnswers != null) {
                string[] answers = possibleAnswers.Split(',');
                foreach (string answer in answers) {
                    result.AddLast(answer);
                }
            }
            return result;
        }
       
    }
}
