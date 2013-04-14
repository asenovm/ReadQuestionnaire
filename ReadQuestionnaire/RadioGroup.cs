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

        public void AddButton(RadioButton button)
        {
            buttons.AddLast(button);
        }

        public string GetCheckedValue()
        {
            foreach (RadioButton button in buttons)
            {
                if (button.Checked)
                {
                    return button.Tag.ToString();
                }
            }
            return "";
        }

        public bool HasChecked()
        {
            foreach (RadioButton button in buttons)
            {
                if (button.Checked)
                {
                    return true;
                }
            }
            return false;
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

        public void Clear()
        {
            buttons.Clear();
        }

        public bool Contains(Control control)
        {
            return buttons.Contains(control);
        }

    }
}
