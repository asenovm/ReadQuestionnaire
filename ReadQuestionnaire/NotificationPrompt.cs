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

        private const string MESSAGE_NOT_CHECKED_RADIO = "Трябва да маркирате поне една опция.";

        private const string MESSAGE_NO_INPUT = "Трябва да въведете поне 1 символ във всяко поле.";

        private const string MESSAGE_EXPRIMENT_END = "\tБлагодарим, че взехте участие в първата част на изследването. Моля, НЕ натискайте бутона ОК преди ръководителят на експеримента да дойде и да отбележи натрупаното от Вас количество омниум бонум. Преди да получите съответстващото му заплащане е необходимо да попълните въпросник относно Вашата стратегия по време на играта и личните Ви предпочитания.";

        public void ShowExperimentEndPrompt()
        {

            ShowMessage(MESSAGE_EXPRIMENT_END, PROMPT_NAME_EXPRIMENT);
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
            Console.Beep();
            MessageBox.Show(message, promptName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
        }
    }
}
