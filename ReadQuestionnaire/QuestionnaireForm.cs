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

        public MainContainer()
        {
            InitializeComponent();

            questionnaire = new Questionnaire();

            Question currentQuestion = questionnaire.GetNextQuestion();
            questionTitle.Text = currentQuestion.title;
        }

        private void OnNextQuestionRequired(object sender, EventArgs e)
        {
            if (!IsQuestionAnswered()) {
                MessageBox.Show("Трябва да въведете поне 1000 символа като отговор на въпроса",
                                "READ Questionnaire",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!questionnaire.HasNextQuestion()) {
                DialogResult result = MessageBox.Show("Това беше последният въпрос. Благодарим ви за участието!", "READ Questionnaire",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                if (result == DialogResult.OK) {
                    Close();
                }
                return;
            }

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
