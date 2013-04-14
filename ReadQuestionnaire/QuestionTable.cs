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

        private const int WIDTH_COLUMN = 80;

        private const int HEIGHT_COLUMN = 60;

        private const int WIDTH_COLUMN_ANSWER_LABEL = 150;

        private const int WIDTH_BORDER = 2;

        private LinkedList<RadioGroup> radioGroups;

        private TextBoxGroup textBoxGroup;

        public QuestionTable(Control parent, Question question)
        {
            radioGroups = new LinkedList<RadioGroup>();
            textBoxGroup = new TextBoxGroup();

            LinkedList<string> answers = question.GetPossibleAnswers();
            LinkedList<string> headers = question.GetHeaders();

            int emptyHeaders = headers.Contains("") || answers.Count > 0 ? 1 : 0;

            Width = (headers.Count - emptyHeaders) * WIDTH_COLUMN + emptyHeaders * WIDTH_COLUMN_ANSWER_LABEL;
            Height = (Math.Max(answers.Count, 1) + Math.Min(headers.Count, 1)) * HEIGHT_COLUMN;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            AttachHeaders(question);

            for (int i = 0; i < answers.Count; ++i)
            {
                AttachAnswerLabel(question, i);
                AttachAnswerFields(question, i);
            }

            if (answers.Count == 0)
            {
                AttachAnswerFields(question, 0);
            }

        }

        public bool IsFilled()
        {
            bool areRadioGroupsFilled = true;
            foreach (RadioGroup group in radioGroups)
            {
                areRadioGroupsFilled = areRadioGroupsFilled && group.HasChecked();
            }

            return areRadioGroupsFilled && textBoxGroup.IsFilled();
        }

        public string GetValue()
        {
            StringBuilder builder = new StringBuilder();
            foreach (RadioGroup group in radioGroups)
            {
                builder.Append(group.GetCheckedValue());
                builder.Append(" ");
            }

            for (int i = 0; i < textBoxGroup.Count; ++i)
            {
                builder.Append(textBoxGroup.ElementAt(i).Text);
                builder.Append(" ");
            }

            return builder.ToString();
        }


        private void AttachAnswerLabel(Question question, int row)
        {
            LinkedList<string> headers = question.GetHeaders();
            string answer = question.GetPossibleAnswers().ElementAt(row);

            Label label = new Label();
            label.Font = new Font(FontFamily.GenericSansSerif, 7);
            label.Dock = DockStyle.Fill;
            label.Text = answer;
            label.Margin = new Padding(0);
            label.BackColor = BackgroundColor.YELLOW;
            label.Height = HEIGHT_COLUMN;
            label.Width = WIDTH_COLUMN_ANSWER_LABEL;
            Controls.Add(label, 0, row + Math.Min(headers.Count, 1));
        }

        private void AttachAnswerFields(Question question, int row)
        {
            LinkedList<string> headers = question.GetHeaders();
            LinkedList<string> answers = question.GetPossibleAnswers();

            RadioGroup group = new RadioGroup();

            int limit = answers.Count == 0 ? headers.Count : headers.Count - 1;
            int increment = answers.Count == 0 ? 0 : 1;

            for (int j = 0; j < limit; ++j)
            {
                Panel container = GetContainer(question, headers);
                Control control = GetControl(question, headers, group, j + increment);

                if (j == limit - 1)
                {
                    container.Width = container.Width - limit - WIDTH_BORDER;
                }

                container.Controls.Add(control);

                Controls.Add(container, j + increment, row + 1);
            }

            if (question.answerType == AnswerType.RADIO)
            {
                radioGroups.AddLast(group);
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
                label.BackColor = BackgroundColor.YELLOW;
                int borderWidth = i == headers.Count - 1 ? headers.Count + WIDTH_BORDER : 0;
                label.Width = WIDTH_COLUMN - borderWidth;
                label.Height = HEIGHT_COLUMN - WIDTH_BORDER;
                if (label.Text.Length == 0 || (i == 0 && question.GetPossibleAnswers().Count > 0))
                {
                    label.Width = WIDTH_COLUMN_ANSWER_LABEL - borderWidth;
                }
            }
        }

        private Control GetControl(Question question, LinkedList<string> headers, RadioGroup group, int headerItem)
        {
            Control control = null;
            if (question.answerType == AnswerType.TEXTBOX)
            {
                control = new TextBox();
                TextBox textBox = control as TextBox;
                textBox.Multiline = true;
                textBoxGroup.AddBox(textBox);
            }
            else
            {
                control = new RadioButton();
                control.Tag = headers.ElementAt(headerItem);

                RadioButton radioButton = control as RadioButton;
                group.AddButton(radioButton);
                radioButton.CheckedChanged += OnRadioCheckedChange;
            }

            control.Dock = DockStyle.Fill;
            control.Padding = new Padding(WIDTH_COLUMN / 2 - 5, 0, 0, 0);

            return control;
        }

        private Panel GetContainer(Question question, LinkedList<string> headers)
        {
            Panel container = new Panel();
            container.Width = WIDTH_COLUMN;
            container.Height = HEIGHT_COLUMN - WIDTH_BORDER;
            container.BackColor = BackgroundColor.GREEN;
            container.Margin = new Padding(0);
            container.Anchor = AnchorStyles.None;
            container.Dock = DockStyle.Fill;

            return container;
        }

        private void OnRadioCheckedChange(object sender, EventArgs e)
        {
            RadioButton button = sender as RadioButton;
            foreach (RadioGroup group in radioGroups)
            {
                if (group.Contains(button))
                {
                    group.OnCheckedChange(button);
                }
            }
        }
    }
}
