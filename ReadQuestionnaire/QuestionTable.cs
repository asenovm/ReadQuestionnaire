﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ReadQuestionnaire
{
    public class QuestionTable : TableLayoutPanel
    {
        private const int PADDING_FORM = 5;

        public QuestionTable(Control parent, Question question)
        {
            Width = parent.Width - PADDING_FORM;
            Height = parent.Height - PADDING_FORM;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            AttachHeaders(question);

            LinkedList<string> answers = question.GetPossibleAnswers();

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

        private void AttachAnswerLabel(Question question, int row)
        {
            LinkedList<string> headers = question.GetHeaders();
            string answer = question.GetPossibleAnswers().ElementAt(row);

            Label label = new Label();
            label.Dock = DockStyle.Fill;
            label.Text = answer;
            label.Margin = new Padding(0);
            label.BackColor = BackgroundColor.YELLOW;
            label.Height = (2 * Height / 3) / question.GetPossibleAnswers().Count - PADDING_FORM;
            Controls.Add(label, 0, row + (headers.Count > 0 ? 1 : 0));
        }

        private void AttachAnswerFields(Question question, int row)
        {
            LinkedList<string> headers = question.GetHeaders();

            for (int j = 0; j < headers.Count; ++j)
            {
                Control control = null;
                if (question.answerType == AnswerType.TEXTBOX)
                {
                    control = new TextBox();
                    (control as TextBox).Multiline = true;
                }
                else
                {
                    control = new RadioButton();
                    control.Padding = new Padding(control.Width / 2, 0, 0, 0);
                    control.BackColor = BackgroundColor.GREEN;
                }

                control.Anchor = AnchorStyles.None;
                control.Dock = DockStyle.Fill;
                control.Margin = new Padding(0);
                control.Width = Width / (headers.Count + 1);
                control.Height = (2 * Height / 3) / Math.Max(1, question.GetPossibleAnswers().Count);

                Controls.Add(control, j + (question.GetPossibleAnswers().Count > 0 ? 1 : 0), row + 1);
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
                label.Width = Width / headers.Count;
                label.Height = Height / 3;
            }
        }
    }
}
