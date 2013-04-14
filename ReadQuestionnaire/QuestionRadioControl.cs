using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ReadQuestionnaire
{
    public class QuestionRadioControl : FlowLayoutPanel
    {
        private RadioButton radioButton;

        public RadioButton RadioButton { get { return radioButton; } }

        private const int PADDING_FORM = 2;

        public QuestionRadioControl(Control parent, Question question, string answer)
        {
            LinkedList<string> answers = question.GetPossibleAnswers();

            Margin = new Padding(PADDING_FORM, 0, 0, 0);
            Width = (parent.Width - answers.Count * PADDING_FORM) / answers.Count;
            Height = parent.Height;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = BackgroundColor.GREEN;
            FlowDirection = FlowDirection.TopDown;

            radioButton = new RadioButton();
            radioButton.Margin = new Padding(Width / 2, (Height - radioButton.Height) / 2, 0, 0);
            radioButton.Tag = answer;
            Controls.Add(radioButton);

            Label label = new Label();
            label.Font = new Font(FontFamily.GenericSansSerif, 10);
            SizeF size = CreateGraphics().MeasureString(answer, label.Font, 495);
            label.Margin = new Padding((Width - (int)size.Width) / 2, 0, 0, 0);
            label.Width = Width;
            label.Height = Height - radioButton.Location.Y - radioButton.Height - 2 * PADDING_FORM;
            label.Text = answer;
            Controls.Add(label);
        }

    }
}
