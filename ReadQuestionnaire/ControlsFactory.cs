using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReadQuestionnaire
{
    public class ControlsFactory
    {
        public static Control from(Question question, Control parent, string answer)
        {
            switch (question.type)
            {
                case QuestionType.MULTIPLE_CHOICE:
                    return new QuestionRadioControl(parent, question, answer);
                case QuestionType.TABLE:
                    return new QuestionTable();
                default:
                    return new QuestionTable();
            }
        }
    }
}
