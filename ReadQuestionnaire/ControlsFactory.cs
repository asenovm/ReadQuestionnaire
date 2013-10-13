using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Read
{
    public class ControlsFactory
    {
        public static Control from(Question question, Control parent, string answer)
        {
            if (question.type == QuestionType.MULTIPLE_CHOICE)
            {
                return new QuestionRadioControl(parent, question, answer);
            }
            else
            {
                return new QuestionTable(parent, question);
            }
        }
    }
}
