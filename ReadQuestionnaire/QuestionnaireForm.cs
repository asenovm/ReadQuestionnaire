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
        private const string DEFAULT_TEXT_ANSWER_BOX = "Моля отговорете на въпроса с не по-малко от 1000 символа";

        private const int LENGTH_ANSWER_MIN = 1000;

        private Questionnaire questionnaire;

        private NotificationPrompt prompt;

        private AnswerRecorder recorder;

        public MainContainer()
        {
            InitializeComponent();

            prompt = new NotificationPrompt();
            questionnaire = new Questionnaire();
            recorder = new AnswerRecorder();

            Question currentQuestion = questionnaire.GetNextQuestion();
            questionTitle.Text = currentQuestion.title;
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
                return;
            }

            recorder.WriteAnswer(questionTitle.Text, answerBox.Text);

            questionTitle.Text = questionnaire.GetNextQuestion().title;
            answerBox.Text = DEFAULT_TEXT_ANSWER_BOX;
            answerBox.Focus();
            answerBox.SelectAll();
        }

        private bool IsQuestionAnswered() {
            return answerBox.Text.Length >= LENGTH_ANSWER_MIN;
        }
    }
}
