using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace ReadQuestionnaire
{
    public class InputValidator
    {

        private const int LENGTH_ANSWER_MIN = 300;

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

        public bool ValidateAnswers(Question question) {
            switch (question.type)
            {
                case QuestionType.OPEN:
                    if (!IsOpenQuestionAnswered())
                    {
                        prompt.ShowSmallInputPrompt();
                        return false;
                    }
                    break;
                case QuestionType.MULTIPLE_CHOICE:
                    if (!IsMultipleChoiceQuestionAnswered())
                    {
                        prompt.ShowNotCheckedRadioPrompt();
                        return false;
                    }
                    break;
                case QuestionType.TABLE:
                    if (!IsTableQuestionAnswered())
                    {
                        if (question.answerType == AnswerType.RADIO)
                        {
                            prompt.ShowNotCheckedRadioPrompt();
                        }
                        else
                        {
                            prompt.ShowNoInputPrompt();
                        }
                        return false;
                    }
                    break;
            }
            return true;
        }

        private bool IsOpenQuestionAnswered()
        {
            return answerBox.Text.Length >= LENGTH_ANSWER_MIN;
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
