using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReadQuestionnaire
{
    public class NotificationPrompt
    {

        private const string PROMPT_NAME = "READ Questionnaire";

        private const string MESSAGE_SMALL_INPUT = "Трябва да въведете поне 300 символа като отговор на въпроса.";

        private const string MESSAGE_LAST_QUESTION = "Това беше последният въпрос. Благодарим ви за участието!";

        private const string MESSAGE_NOT_CHECKED_RADIO = "Трябва да маркирате поне една опция.";

        private const string MESSAGE_NO_INPUT = "Трябва да въведете поне 1 символ във всяко поле.";

        public void ShowNoInputPrompt()
        {
            ShowMessage(MESSAGE_NO_INPUT);
        }

        public void ShowNotCheckedRadioPrompt()
        {
            ShowMessage(MESSAGE_NOT_CHECKED_RADIO);
        }

        public void ShowSmallInputPrompt()
        {
            ShowMessage(MESSAGE_SMALL_INPUT);
        }

        public void ShowLastQuestionPrompt()
        {
            DialogResult result = ShowMessage(MESSAGE_LAST_QUESTION);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private DialogResult ShowMessage(String message)
        {
            DialogResult result = MessageBox.Show(message, PROMPT_NAME,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
            return result;
        }
    }
}
