﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReadQuestionnaire
{
    public partial class MainContainer : Form
    {
        private const string DEFAULT_TEXT_ANSWER_BOX = "Моля отговорете на въпроса с не по-малко от 300 символа";

        private const int LENGTH_ANSWER_MIN = 300;

        private RadioGroup group;

        private Questionnaire questionnaire;

        private NotificationPrompt prompt;

        private AnswerRecorder recorder;

        private EmailSender sender;

        public MainContainer()
        {
            InitializeComponent();

            prompt = new NotificationPrompt();
            questionnaire = new Questionnaire();
            recorder = new AnswerRecorder();
            sender = new EmailSender();
            group = new RadioGroup();

            ShowNextQuestion();
        }

        private void OnNextQuestionRequired(object sender, EventArgs e)
        {
            if (!IsQuestionAnswered())
            {
                prompt.ShowSmallInputPrompt();
                return;
            }

            if (!questionnaire.HasNextQuestion())
            {
                prompt.ShowLastQuestionPrompt();
                recorder.WriteAnswer(questionTitle.Text, answerBox.Text);
                this.sender.EmailAnswers();
                return;
            }

            recorder.WriteAnswer(questionTitle.Text, answerBox.Text);

            ShowNextQuestion();
        }

        private void ResetLayout()
        {
            questionHolder.Controls.Clear();
            questionHolder.Visible = false;

            answerBox.Visible = false;
            characterCount.Visible = false;
            characterCountLabel.Visible = false;
        }

        private void ShowNextQuestion()
        {
            Question nextQuestion = questionnaire.GetNextQuestion();
            ResetLayout();
            questionTitle.Text = nextQuestion.title;
            switch (nextQuestion.type)
            {
                case QuestionType.OPEN:
                    ShowOpenQuestion(nextQuestion);
                    break;
                case QuestionType.MULTIPLE_CHOICE:
                    ShowMultipleChoiceQuestion(nextQuestion);
                    break;
                case QuestionType.TABLE:
                    ShowTableQuestion(nextQuestion);
                    break;
            }
        }

        private void ShowOpenQuestion(Question question)
        {
            characterCountLabel.Visible = true;
            characterCount.Visible = true;
            answerBox.Visible = true;

            answerBox.Text = DEFAULT_TEXT_ANSWER_BOX;
            answerBox.Focus();
            answerBox.SelectAll();
        }

        private void ShowTableQuestion(Question question)
        {

            questionHolder.Visible = true;

            TableLayoutPanel table = new TableLayoutPanel();
            table.Width = questionHolder.Width - 5;
            table.Height = questionHolder.Height - 5;
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            LinkedList<string> headers = question.GetHeaders();
            for (int i = 0; i < headers.Count; ++i)
            {
                Label label = new Label();
                label.Text = headers.ElementAt(i);
                table.Controls.Add(label, i, 0);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = Color.Red;
                label.Margin = new Padding(0);
                label.BackColor = Color.FromArgb(255, 226, 233, 116);
                label.Width = table.Width / headers.Count;
            }

            LinkedList<string> answers = question.GetPossibleAnswers();

            for (int i = 0; i < answers.Count; ++i)
            {
                string answer = answers.ElementAt(i);
                Label label = new Label();
                label.Dock = DockStyle.Fill;
                label.Text = answer;
                table.Controls.Add(label, 0, i + (headers.Count > 0 ? 1 : 0));

                for (int j = 0; j < headers.Count - 1; ++j)
                {
                    Control control = null;
                    if (question.answerType == AnswerType.TEXTBOX)
                    {
                        control = new TextBox();
                        control.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        control = new RadioButton();
                    }

                    table.Controls.Add(control, j, i + (headers.Count > 0 ? 1 : 0));
                }
            }

            if (answers.Count == 0)
            {
                for (int j = 0; j < headers.Count; ++j)
                {
                    Control control = null;
                    if (question.answerType == AnswerType.TEXTBOX)
                    {
                        control = new TextBox();
                        control.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        control = new RadioButton();
                    }
                    control.BackColor = Color.FromArgb(255, 50, 205, 50);
                    control.Anchor = AnchorStyles.None;
                    control.Dock = DockStyle.Fill;
                    control.Margin = new Padding(0);
                    control.Padding = new Padding(control.Width/2 + 20, 0, 0, 0);
                    table.Controls.Add(control, j, 1);
                }
            }

            questionHolder.Controls.Add(table);
        }

        private void ShowMultipleChoiceQuestion(Question question)
        {
            questionHolder.Visible = true;

            foreach (string answer in question.GetPossibleAnswers())
            {
                QuestionRadioControl control = ControlsFactory.from(question, questionHolder, answer) as QuestionRadioControl;
                control.RadioButton.CheckedChanged += OnRadioButtonChecked;
                group.AddRadioButton(control.RadioButton);
                questionHolder.Controls.Add(control);
            }
        }


        private void OnRadioButtonChecked(object sender, EventArgs e)
        {
            group.OnCheckedChange(sender as RadioButton);
        }

        private bool IsQuestionAnswered()
        {
            return !answerBox.Visible || answerBox.Text.Length >= LENGTH_ANSWER_MIN;
        }

        private void OnAnswerChanged(object sender, EventArgs e)
        {
            characterCount.Text = answerBox.Text.Length.ToString();
        }
    }
}
