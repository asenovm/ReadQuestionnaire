using System;
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

        private LinkedList<RadioButton> radioButtons;

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
            radioButtons = new LinkedList<RadioButton>();

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

        private void ShowNextQuestion()
        {
            Question nextQuestion = questionnaire.GetNextQuestion();
            switch (nextQuestion.type)
            {
                case QuestionType.OPEN:
                    ShowOpenQuestion(nextQuestion);
                    break;
                case QuestionType.MULTIPLE_CHOICE:
                    ShowMultipleChoiceQuestion(nextQuestion);
                    break;
                case QuestionType.TABLE:
                    break;
            }
        }

        private void ShowOpenQuestion(Question question)
        {
            questionHolder.Visible = false;
            questionHolder.Controls.Clear();

            characterCount.Visible = true;
            answerBox.Visible = true;

            questionTitle.Text = question.title;
            answerBox.Text = DEFAULT_TEXT_ANSWER_BOX;
            answerBox.Focus();
            answerBox.SelectAll();
        }

        private void ShowMultipleChoiceQuestion(Question question)
        {
            answerBox.Visible = false;
            characterCount.Visible = false;
            questionHolder.Visible = true;

            questionTitle.Text = question.title;

            foreach (string answer in question.GetPossibleAnswers())
            {
                FlowLayoutPanel layout = new FlowLayoutPanel();
                layout.Margin = new Padding(2, 0, 0, 0);
                layout.Padding = new Padding(0, 0, 5, 0);
                layout.Width = (questionHolder.Width - question.GetPossibleAnswers().Count * 2) / question.GetPossibleAnswers().Count;
                layout.Height = questionHolder.Height;
                layout.BorderStyle = BorderStyle.FixedSingle;
                layout.BackColor = Color.FromArgb(255, 50, 205, 50);
                layout.FlowDirection = FlowDirection.TopDown;


                RadioButton radioButton = new RadioButton();
                radioButton.CheckedChanged += OnRadioButtonChecked;
                radioButton.Margin = new Padding(layout.Width / 2, layout.Height / 2 - radioButton.Height / 2, 0, 0);
                layout.Controls.Add(radioButton);
                radioButtons.AddLast(radioButton);

                Label label = new Label();
                label.Font = new Font(FontFamily.GenericSansSerif, 10);
                SizeF size = CreateGraphics().MeasureString(answer, label.Font, 495);
                label.Margin = new Padding(layout.Width / 2 - (int)size.Width / 2, 0, 0, 0);
                label.Width = layout.Width;
                label.Height = layout.Height - radioButton.Location.Y - radioButton.Height - 5;
                label.Text = answer;
                layout.Controls.Add(label);

                questionHolder.Controls.Add(layout);
            }
        }

        private void OnRadioButtonChecked(object sender, EventArgs e)
        {
            RadioButton clickedButton = (RadioButton)sender;
            if (!clickedButton.Checked)
            {
                return;
            }

            foreach (var button in radioButtons)
            {
                if (button != clickedButton)
                {
                    button.Checked = false;
                }
            }
        }

        private bool IsQuestionAnswered()
        {
            return answerBox.Text.Length >= LENGTH_ANSWER_MIN;
        }

        private void OnAnswerChanged(object sender, EventArgs e)
        {
            characterCount.Text = answerBox.Text.Length.ToString();
        }
    }
}
