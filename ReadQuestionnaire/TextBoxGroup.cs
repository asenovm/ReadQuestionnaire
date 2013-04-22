using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace Read
{
    public class TextBoxGroup
    {

        private const string REGEX_TEXT_BOX_ANSWER = "^[1-9]$";

        private LinkedList<TextBox> textBoxes;

        public int Count { get { return textBoxes.Count; } }

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
                if (!Regex.IsMatch(box.Text, REGEX_TEXT_BOX_ANSWER))
                {
                    return false;
                }
            }
            return true;
        }

        public TextBox ElementAt(int position)
        {
            return textBoxes.ElementAt(position);
        }
    }
}
