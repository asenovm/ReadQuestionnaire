using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace Read
{
    public partial class QuestionnaireForm : Form
    {
        private const int PADDING_QUESTION_TITLE = 20;

        private RadioGroup group;

        private Questionnaire questionnaire;

        private AnswerRecorder openAnswerRecorder;

        private AnswerRecorder multipleChoiceRecorder;

        private EmailSender sender;

        private InputValidator validator;

        public QuestionnaireForm(string questionnairePath)
        {
            InitializeComponent();

            questionnaire = new Questionnaire(questionnairePath);

            openAnswerRecorder = new AnswerRecorder(FileName.RESULTS_OPEN_ANSWER);
            multipleChoiceRecorder = new AnswerRecorder(FileName.RESULTS_MULTIPLE_CHOICE);

            group = new RadioGroup();
            validator = new InputValidator(answerBox, group, questionHolder);

            ShowNextQuestion();
        }

        private void OnNextQuestionRequired(object sender, EventArgs e)
        {
            Question currentQuestion = questionnaire.GetCurrentQuestion();

            if (!validator.ValidateAnswers(currentQuestion))
            {
                return;
            }

            WriteAnswer(currentQuestion);

            if (questionnaire.HasNextQuestion())
            {
                ShowNextQuestion();
            }
            else
            {
                Hide();
                if (questionnaire.IsLastQuestionnaire())
                {
                    new PersonalInformationForm().Show();
                }
                else
                {
                    new TraitsInstructionForm().Show();
                }
            }
        }

        private void WriteAnswer(Question currentQuestion)
        {
            bool isLastQuestion = currentQuestion.Last && questionnaire.IsLastQuestionnaire();
            if (currentQuestion.type == QuestionType.OPEN)
            {
                openAnswerRecorder.WriteAnswer(answerBox.Text);
            }
            else if (currentQuestion.type == QuestionType.MULTIPLE_CHOICE)
            {
                multipleChoiceRecorder.WriteAnswer(group.GetCheckedValue(), !isLastQuestion);
            }
            else
            {
                IEnumerator enumerator = questionHolder.Controls.GetEnumerator();
                enumerator.MoveNext();
                QuestionTable table = enumerator.Current as QuestionTable;
                multipleChoiceRecorder.WriteAnswer(table.GetValue(), !isLastQuestion);
            }
        }

        private void ResetLayout()
        {
            questionHolder.Controls.Clear();
            questionHolder.Visible = false;
            questionHolder.Width = 845;
            questionHolder.Height = 300;
            questionHolder.Left = 48;
            questionHolder.Top = 116;

            answerBox.Text = "";
            answerBox.Visible = false;
            group.Clear();
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

            questionTitle.Top = questionHolder.Top - GetQuestionHeight() - PADDING_QUESTION_TITLE;
        }

        private int GetQuestionHeight()
        {
            Size textSize = TextRenderer.MeasureText(questionTitle.Text, questionTitle.Font);
            return (textSize.Width / questionTitle.Width) * textSize.Height + textSize.Height;
        }

        private void ShowOpenQuestion(Question question)
        {
            answerBox.Visible = true;

            answerBox.Focus();
            answerBox.SelectAll();
        }

        private void ShowTableQuestion(Question question)
        {
            questionHolder.Visible = true;
            Control control = ControlsFactory.from(question, questionHolder, "");
            questionHolder.Controls.Add(control);
            questionHolder.Top = questionHolder.Top + (questionHolder.Height - control.Height) / 2 + 14;
            questionHolder.Width = control.Width + 14;
            questionHolder.Height = control.Height + 14;
            CenterInContainer(this, questionHolder);
            control.Margin = new Padding((questionHolder.Width - control.Width) / 2, (questionHolder.Height - control.Height) / 2, 0, 0);
        }

        private void ShowMultipleChoiceQuestion(Question question)
        {
            questionHolder.Visible = true;
            LinkedList<string> answers = question.GetPossibleAnswers();

            questionHolder.Width = answers.Count * QuestionRadioControl.WIDTH_CONTROL;
            questionHolder.Height = QuestionRadioControl.HEIGHT_CONTROL;

            foreach (string answer in answers)
            {
                QuestionRadioControl control = ControlsFactory.from(question, questionHolder, answer) as QuestionRadioControl;
                control.RadioButton.CheckedChanged += OnRadioButtonChecked;
                group.AddButton(control.RadioButton);
                questionHolder.Controls.Add(control);
            }

            CenterInContainer(this, questionHolder);
        }

        private void CenterInContainer(Control container, Control control)
        {
            control.Left = (container.Width - control.Width) / 2;
        }


        private void OnRadioButtonChecked(object sender, EventArgs e)
        {
            group.OnCheckedChange(sender as RadioButton);
        }

        private void OnCloseRequired(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

    }
}
