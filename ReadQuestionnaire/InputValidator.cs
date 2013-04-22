using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Read
{
    public class InputValidator
    {

        private NotificationPrompt prompt;

        private TextBox answerBox;

        private RadioGroup group;

        private Control container;

        public InputValidator(TextBox answerBox, RadioGroup group, Control container)
        {
            prompt = new NotificationPrompt();
            this.answerBox = answerBox;
            this.group = group;
            this.container = container;
        }

        public bool ValidateAnswers(Question question)
        {
            if (question.type == QuestionType.MULTIPLE_CHOICE && !IsMultipleChoiceQuestionAnswered())
            {
                prompt.ShowNotCheckedRadioPrompt();
                return false;
            }
            else if (question.type == QuestionType.TABLE && !IsTableQuestionAnswered() && question.answerType == AnswerType.RADIO)
            {
                prompt.ShowNotCheckedRadioPrompt();
                return false;
            }
            else if (question.type == QuestionType.TABLE && !IsTableQuestionAnswered())
            {
                prompt.ShowNoInputPrompt();
                return false;
            }
            return true;
        }

        private bool IsMultipleChoiceQuestionAnswered()
        {
            return group.HasChecked();
        }

        private bool IsTableQuestionAnswered()
        {
            IEnumerator controls = container.Controls.GetEnumerator();
            controls.MoveNext();
            QuestionTable table = (QuestionTable)controls.Current;
            return table.IsFilled();
        }
    }
}
