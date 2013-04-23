using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Read
{
    public class QuestionTable : TableLayoutPanel
    {

        private const int WIDTH_COLUMN = 95;

        private const int HEIGHT_COLUMN = 40;

        private const int HEIGHT_COLUMN_HEADER = 60;

        private const int HEIGHT_COLUMN_OPEN_OPTION = 50;

        private const int WIDTH_COLUMN_ANSWER_LABEL = 300;

        private const int WIDTH_BORDER = 2;

        private const int FONT_SIZE_ANSWER_LABEL = 8;

        private const string TEXT_OPEN_OPTION = "Друго (напишете какво): ";

        private const string TEXT_OPEN_OPTION_DEFAULT_ANSWER = "друго_няма";

        private const string DELIMITER_VALUE = ",";

        private const string REGEX_OPEN_OPTION_ANSWER = "^[1-9]+$";

        private LinkedList<RadioGroup> radioGroups;

        private TextBoxGroup textBoxGroup;

        private TextBox openOptionAnswerBox;

        private TextBox openOptionQuestionBox;

        public QuestionTable(Control parent, Question question)
        {
            radioGroups = new LinkedList<RadioGroup>();
            textBoxGroup = new TextBoxGroup();

            LinkedList<string> answers = question.GetPossibleAnswers();
            LinkedList<Option> headers = question.GetOptions();

            Width = GetControlWidth(headers.Count, GetEmptyHeadersCount(answers));
            Height = GetControlHeight(answers.Count, headers.Count);
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            AttachHeaders(question);

            for (int i = 0; i < answers.Count; ++i)
            {
                AttachAnswerLabel(answers.ElementAt(i), headers.Count, i);
                AttachAnswerFields(question, i);
            }

            if (question.hasOpenOption)
            {
                Height = Height + HEIGHT_COLUMN_OPEN_OPTION;
                AttachOpenOptionLabel(question, answers.Count + 1, 0);
                AttachOpenOptionAnswer(question, answers.Count + 1, 1);
            }

            if (answers.Count == 0)
            {
                AttachAnswerFields(question, 0);
            }
        }

        private void AttachOpenOptionLabel(Question question, int row, int column)
        {
            Controls.Add(GetOpenOptionControl(), column, row);
        }

        private void AttachOpenOptionAnswer(Question question, int row, int column)
        {
            openOptionAnswerBox = new TextBox();
            openOptionAnswerBox.Multiline = true;
            openOptionAnswerBox.Dock = DockStyle.Fill;
            openOptionAnswerBox.Margin = new Padding(0);
            Controls.Add(openOptionAnswerBox, column, row);
        }

        private Control GetOpenOptionControl()
        {
            FlowLayoutPanel flowLayout = new FlowLayoutPanel();
            flowLayout.FlowDirection = FlowDirection.TopDown;
            flowLayout.Dock = DockStyle.Fill;

            Label label = new Label();
            label.Text = TEXT_OPEN_OPTION;
            label.Width = WIDTH_COLUMN;
            label.AutoSize = true;
            label.Margin = new Padding(0);

            openOptionQuestionBox = new TextBox();

            flowLayout.Controls.Add(label);
            flowLayout.Controls.Add(openOptionQuestionBox);

            flowLayout.BackColor = BackgroundColor.YELLOW;
            flowLayout.Margin = new Padding(0);

            return flowLayout;
        }

        public bool IsFilled()
        {
            bool areRadioGroupsFilled = true;
            foreach (RadioGroup group in radioGroups)
            {
                areRadioGroupsFilled = areRadioGroupsFilled && group.HasChecked();
            }

            bool isOpenOptionFilled = true;
            if (openOptionQuestionBox != null && (openOptionQuestionBox.Text.Length > 0 || openOptionAnswerBox.Text.Length > 0))
            {
                isOpenOptionFilled = Regex.IsMatch(openOptionAnswerBox.Text, REGEX_OPEN_OPTION_ANSWER) && openOptionQuestionBox.Text.Length > 0;
            }

            return areRadioGroupsFilled && textBoxGroup.IsFilled() && isOpenOptionFilled;
        }

        public string GetValue()
        {
            StringBuilder builder = new StringBuilder();

            if (radioGroups.Count > 0)
            {
                builder.Append(radioGroups.First.Value.GetCheckedValue());
            }

            for (int i = 1; i < radioGroups.Count; ++i)
            {
                builder.Append(DELIMITER_VALUE);
                builder.Append(radioGroups.ElementAt(i).GetCheckedValue());
            }

            if (textBoxGroup.Count > 0)
            {
                builder.Append(textBoxGroup.ElementAt(0).Text);
            }

            for (int i = 1; i < textBoxGroup.Count; ++i)
            {
                builder.Append(DELIMITER_VALUE);
                builder.Append(textBoxGroup.ElementAt(i).Text);
            }

            if (openOptionQuestionBox != null && openOptionQuestionBox.Text.Length > 0)
            {
                builder.Append(DELIMITER_VALUE);
                builder.Append(openOptionQuestionBox.Text);
                builder.Append(" ");
                builder.Append(openOptionAnswerBox.Text);
            }
            else if (openOptionQuestionBox != null)
            {
                builder.Append(DELIMITER_VALUE);
                builder.Append(TEXT_OPEN_OPTION_DEFAULT_ANSWER);
            }

            return builder.ToString();
        }

        private int GetEmptyHeadersCount(LinkedList<string> answers)
        {
            return answers.Count > 0 ? 1 : 0;
        }

        private int GetControlHeight(int answersCount, int headersCount)
        {
            return Math.Max(answersCount, 1) * HEIGHT_COLUMN + Math.Min(headersCount, 1) * HEIGHT_COLUMN_HEADER;
        }

        private int GetControlWidth(int headersCount, int emptyHeadersCount)
        {
            return (headersCount - emptyHeadersCount) * WIDTH_COLUMN + emptyHeadersCount * WIDTH_COLUMN_ANSWER_LABEL;
        }


        private void AttachAnswerLabel(string answer, int headerCount, int row)
        {
            Label label = new Label();
            label.Font = new Font(FontFamily.GenericSansSerif, FONT_SIZE_ANSWER_LABEL);
            label.Dock = DockStyle.Fill;
            label.Text = answer;
            label.Margin = new Padding(0);
            label.BackColor = BackgroundColor.YELLOW;
            label.Height = HEIGHT_COLUMN;
            label.Width = WIDTH_COLUMN_ANSWER_LABEL;

            Controls.Add(label, 0, row + Math.Min(headerCount, 1));
        }

        private void AttachAnswerFields(Question question, int row)
        {
            LinkedList<Option> headers = question.GetOptions();
            LinkedList<string> answers = question.GetPossibleAnswers();

            RadioGroup group = new RadioGroup();

            int limit = answers.Count == 0 ? headers.Count : headers.Count - 1;
            int increment = answers.Count == 0 ? 0 : 1;

            for (int j = 0; j < limit; ++j)
            {
                Panel container = GetContainer();
                Control control = GetControl(question, headers.ElementAt(j + increment), group);

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
            LinkedList<Option> headers = question.GetOptions();
            for (int i = 0; i < headers.Count; ++i)
            {
                Label label = new Label();
                label.Text = headers.ElementAt(i).header;
                Controls.Add(label, i, 0);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Margin = new Padding(0);
                label.BackColor = BackgroundColor.YELLOW;
                int borderWidth = i == headers.Count - 1 ? headers.Count + WIDTH_BORDER : 0;
                label.Width = WIDTH_COLUMN - borderWidth;
                label.Height = HEIGHT_COLUMN_HEADER - WIDTH_BORDER;
                if (label.Text.Length == 0 || (i == 0 && question.GetPossibleAnswers().Count > 0))
                {
                    label.Width = WIDTH_COLUMN_ANSWER_LABEL - borderWidth;
                }
            }
        }

        private Control GetControl(Question question, Option header, RadioGroup group)
        {
            Control control = null;
            if (question.answerType == AnswerType.TEXTBOX)
            {
                control = GetTextBoxControl();
            }
            else
            {
                control = GetRadioControl(group, header);
            }

            control.Dock = DockStyle.Fill;
            control.Padding = new Padding(WIDTH_COLUMN / 2 - 5, 0, 0, 0);
            control.Margin = new Padding(0);

            return control;
        }

        private TextBox GetTextBoxControl()
        {
            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBoxGroup.AddBox(textBox);
            return textBox;
        }

        private Control GetRadioControl(RadioGroup group, Option header)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.Tag = header.value;

            group.AddButton(radioButton);
            radioButton.CheckedChanged += OnRadioCheckedChange;

            return radioButton;
        }

        private Panel GetContainer()
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
