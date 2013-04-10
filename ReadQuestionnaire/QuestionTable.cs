using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ReadQuestionnaire
{
    public class QuestionTable : TableLayoutPanel
    {
        public QuestionTable(Control parent, Question question)
        {
            Width = parent.Width - 5;
            Height = parent.Height - 5;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            AttachHeaders(question);

            LinkedList<string> answers = question.GetPossibleAnswers();

            for (int i = 0; i < answers.Count; ++i)
            {
                AttachAnswerLabel(question, i);
                //                AttachAnswerFields(question);
            }

            if (answers.Count == 0)
            {
                AttachAnswerFields(question);
            }

        }

        private void AttachAnswerLabel(Question question, int row)
        {
            LinkedList<string> headers = question.GetHeaders();
            string answer = question.GetPossibleAnswers().ElementAt(row);

            Label label = new Label();
            label.Dock = DockStyle.Fill;
            label.Text = answer;
            label.Height = (2 * Height / 3) / question.GetPossibleAnswers().Count - 10;
            Controls.Add(label, 0, row + (headers.Count > 0 ? 1 : 0));
        }

        private void AttachAnswerFields(Question question)
        {
            LinkedList<string> headers = question.GetHeaders();

            for (int j = 0; j < headers.Count; ++j)
            {
                Control control = null;
                if (question.answerType == AnswerType.TEXTBOX)
                {
                    control = new TextBox();
                }
                else
                {
                    control = new RadioButton();
                }

                control.BackColor = Color.FromArgb(255, 50, 205, 50);
                control.Anchor = AnchorStyles.None;
                control.Dock = DockStyle.Fill;
                control.Margin = new Padding(0);
                control.Width = Width / headers.Count;
                control.Height = 2 * Height / 3;
                control.Padding = new Padding(control.Width / 2, 0, 0, 0);

                Controls.Add(control, j, 1);
            }
        }

        private void AttachHeaders(Question question)
        {
            LinkedList<string> headers = question.GetHeaders();
            for (int i = 0; i < headers.Count; ++i)
            {
                Label label = new Label();
                label.Text = headers.ElementAt(i);
                Controls.Add(label, i, 0);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Margin = new Padding(0);
                label.BackColor = Color.FromArgb(255, 226, 233, 116);
                label.Width = Width / headers.Count;
                label.Height = Height / 3;
            }
        }
    }
}
