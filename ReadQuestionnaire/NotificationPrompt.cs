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

        private const string MESSAGE_SMALL_INPUT = "Трябва да въведете поне 300 символа като отговор на въпроса";

        private const string MESSAGE_LAST_QUESTION = "Това беше последният въпрос. Благодарим ви за участието!";

        public void ShowSmallInputPrompt() {
            MessageBox.Show(MESSAGE_SMALL_INPUT,
                    PROMPT_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        public void ShowLastQuestionPrompt() {
            DialogResult result = MessageBox.Show(MESSAGE_LAST_QUESTION, PROMPT_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            if (result == DialogResult.OK) {
                Application.Exit();
            }
        }
    }
}
