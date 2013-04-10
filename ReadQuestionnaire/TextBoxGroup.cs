using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReadQuestionnaire
{
    public class TextBoxGroup
    {
        private LinkedList<TextBox> textBoxes;

        public TextBoxGroup()
        {
            textBoxes = new LinkedList<TextBox>();
        }

        public void AddBox(TextBox box)
        {
            textBoxes.AddLast(box);
        }

        public bool IsFilled()
        {
            foreach (TextBox box in textBoxes)
            {
                if (box.Text.Length == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
