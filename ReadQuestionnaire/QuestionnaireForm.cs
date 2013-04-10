using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

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
            Question currentQuestion = questionnaire.GetCurrentQuestion();
            switch (currentQuestion.type)
            {
                case QuestionType.OPEN:
                    if (!IsOpenQuestionAnswered())
                    {
                        prompt.ShowSmallInputPrompt();
                        return;
                    }
                    break;
                case QuestionType.MULTIPLE_CHOICE:
                    if (!IsMultipleChoiceQuestionAnswered())
                    {
                        prompt.ShowNotCheckedRadioPrompt();
                        return;
                    }
                    break;
                case QuestionType.TABLE:
                    if (!IsTableQuestionAnswered())
                    {
                        if (currentQuestion.answerType == AnswerType.RADIO)
                        {
                            prompt.ShowNotCheckedRadioPrompt();
                        }
                        else {
                            prompt.ShowNoInputPrompt();
                        }
                        return;
                    }
                    break;
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
            questionHolder.Controls.Add(ControlsFactory.from(question, questionHolder, ""));
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

        private bool IsOpenQuestionAnswered()
        {
            return answerBox.Text.Length >= LENGTH_ANSWER_MIN;
        }

        private void OnAnswerChanged(object sender, EventArgs e)
        {
            characterCount.Text = answerBox.Text.Length.ToString();
        }

        private bool IsMultipleChoiceQuestionAnswered()
        {
            return group.HasChecked();
        }

        private bool IsTableQuestionAnswered()
        {
            IEnumerator controls = questionHolder.Controls.GetEnumerator();
            controls.MoveNext();
            Control table = (Control)controls.Current;
            foreach (Control control in table.Controls)
            {
                if (control is TextBox)
                {
                    TextBox box = control as TextBox;
                    if (box.Text.Length == 0)
                    {
                        return false;
                    }
                }
                else if (control is RadioButton)
                {
                    Console.WriteLine("in the radio button if!!!!");
                }
            }
            return true;
        }
    }
}
