using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Read
{
    public class NotificationPrompt
    {

        private const string PROMPT_NAME_QUESTIONNAIRE = "READ Questionnaire";

        private const string PROMPT_NAME_EXPRIMENT = "Експеримент";

        private const string MESSAGE_FORM_NOT_FILLED = "Моля попълнете всички необходими данни";

        private const string MESSAGE_NOT_CHECKED_RADIO = "Трябва да маркирате поне една опция.";

        private const string MESSAGE_NO_INPUT = "Трябва да въведете поне 1 символ във всяко поле.";

        public void ShowFormNotFilledPrompt() {
            ShowMessage(MESSAGE_FORM_NOT_FILLED);
        }

        public void ShowNoInputPrompt()
        {
            ShowMessage(MESSAGE_NO_INPUT);
        }

        public void ShowNotCheckedRadioPrompt()
        {
            ShowMessage(MESSAGE_NOT_CHECKED_RADIO);
        }

        private void ShowMessage(string message) {
            ShowMessage(message, PROMPT_NAME_QUESTIONNAIRE);
        }

        private void ShowMessage(string message, string promptName)
        {
            MessageBox.Show(message, promptName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        }
    }
}
