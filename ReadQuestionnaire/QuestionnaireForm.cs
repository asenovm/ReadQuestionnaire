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

            ShowNextQuestion();
        }

        private void OnNextQuestionRequired(object sender, EventArgs e)
        {
            if (!IsQuestionAnswered()) {
                prompt.ShowSmallInputPrompt();
                return;
            }

            if (!questionnaire.HasNextQuestion()) {
                prompt.ShowLastQuestionPrompt();
                recorder.WriteAnswer(questionTitle.Text, answerBox.Text);
                this.sender.EmailAnswers();
                return;
            }

            recorder.WriteAnswer(questionTitle.Text, answerBox.Text);

            ShowNextQuestion();
        }

        private void ShowNextQuestion() {
            Question nextQuestion = questionnaire.GetNextQuestion();
            switch (nextQuestion.type) { 
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

        private void ShowOpenQuestion(Question question) {
            Console.WriteLine("showing open question!");
            questionHolder.Visible = false;
            questionHolder.Controls.Clear();

            answerBox.Visible = true;

            questionTitle.Text = question.title;
            answerBox.Text = DEFAULT_TEXT_ANSWER_BOX;
            answerBox.Focus();
            answerBox.SelectAll();
        }

        private void ShowMultipleChoiceQuestion(Question question) {
            Console.WriteLine("showing multiple choice question!");
            answerBox.Visible = false;
            questionHolder.Visible = true;

            questionTitle.Text = question.title;
            foreach (string answer in question.GetPossibleAnswers()) {
                RadioButton button = new RadioButton();
                button.Text = answer;
                questionHolder.Controls.Add(button);
            }
        }

        private bool IsQuestionAnswered() {
            return answerBox.Text.Length >= LENGTH_ANSWER_MIN;
        }

        private void OnAnswerChanged(object sender, EventArgs e)
        {
            characterCount.Text = answerBox.Text.Length.ToString();
        }
    }
}
