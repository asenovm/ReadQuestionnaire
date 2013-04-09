using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReadQuestionnaire
{
    public class RadioGroup
    {
        private LinkedList<RadioButton> buttons;

        public RadioGroup()
        {
            buttons = new LinkedList<RadioButton>();
        }

        public void AddRadioButton(RadioButton button)
        {
            buttons.AddLast(button);
        }

        public void OnCheckedChange(RadioButton clicked)
        {
            if (!clicked.Checked)
            {
                return;
            }

            foreach (RadioButton button in buttons)
            {
                if (button != clicked)
                {
                    button.Checked = false;
                }
            }
        }

    }
}
