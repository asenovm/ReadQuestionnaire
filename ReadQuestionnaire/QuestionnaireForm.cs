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

        private RadioGroup group;

        private Questionnaire questionnaire;

        private NotificationPrompt prompt;

        private AnswerRecorder recorder;

        private EmailSender sender;

        private InputValidator validator;

        public MainContainer()
        {
            InitializeComponent();

            prompt = new NotificationPrompt();
            questionnaire = new Questionnaire();
            recorder = new AnswerRecorder();
            sender = new EmailSender();
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

            if (!questionnaire.HasNextQuestion())
            {
                prompt.ShowLastQuestionPrompt();
                recorder.WriteAnswer(currentQuestion, group, questionHolder, answerBox);
                this.sender.EmailAnswers();
                return;
            }

            recorder.WriteAnswer(currentQuestion, group, questionHolder, answerBox);

            ShowNextQuestion();
        }

        private void ResetLayout()
        {
            questionHolder.Controls.Clear();
            questionHolder.Visible = false;
            questionHolder.Width = 845;
            questionHolder.Height = 521;
            questionHolder.Left = 53;
            questionHolder.Top = 123;


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
            questionHolder.Width = control.Width + 14;
            questionHolder.Height = control.Height + 14;
            CenterInContainer(this, questionHolder);
            control.Margin = new Padding(questionHolder.Width / 2 - control.Width / 2, questionHolder.Height / 2 - control.Height / 2, 0, 0);
        }

        private void ShowMultipleChoiceQuestion(Question question)
        {
            questionHolder.Visible = true;
            LinkedList<string> answers = question.GetPossibleAnswers();

            questionHolder.Width = answers.Count * 120;
            questionHolder.Height = 140;

            foreach (string answer in answers)
            {
                QuestionRadioControl control = ControlsFactory.from(question, questionHolder, answer) as QuestionRadioControl;
                control.RadioButton.CheckedChanged += OnRadioButtonChecked;
                group.AddButton(control.RadioButton);
                questionHolder.Controls.Add(control);
            }

            int controlsWidth = 0;
            int controlsHeight = 0;

            foreach (Control control in questionHolder.Controls)
            {
                controlsWidth += control.Width;
                controlsHeight = control.Height;
            }

            CenterInContainer(this, questionHolder);
        }

        private void CenterInContainer(Control container, Control control)
        {
            control.Left = container.Width / 2 - control.Width / 2;
            control.Top = container.Height / 2 - control.Height / 2;
        }


        private void OnRadioButtonChecked(object sender, EventArgs e)
        {
            group.OnCheckedChange(sender as RadioButton);
        }

    }
}
