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

        public QuestionRadioControl(Control parent, Question question, string answer)
        {
            Margin = new Padding(2, 0, 0, 0);
            Width = (parent.Width - question.GetPossibleAnswers().Count * 2) / question.GetPossibleAnswers().Count;
            Height = parent.Height;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.FromArgb(255, 50, 205, 50);
            FlowDirection = FlowDirection.TopDown;


            radioButton = new RadioButton();
            radioButton.Margin = new Padding(Width / 2, Height / 2 - radioButton.Height / 2, 0, 0);
            Controls.Add(radioButton);

            Label label = new Label();
            label.Font = new Font(FontFamily.GenericSansSerif, 10);
            SizeF size = CreateGraphics().MeasureString(answer, label.Font, 495);
            label.Margin = new Padding(Width / 2 - (int)size.Width / 2, 0, 0, 0);
            label.Width = Width;
            label.Height = Height - radioButton.Location.Y - radioButton.Height - 5;
            label.Text = answer;
            Controls.Add(label);
        }

    }
}
