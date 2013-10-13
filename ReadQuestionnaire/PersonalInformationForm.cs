using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Read
{
    public partial class PersonalInformationForm : Form, IEmailSenderCallback
    {

        private AnswerRecorder answerRecorder;

        private EmailSender emailSender;

        public PersonalInformationForm()
        {
            InitializeComponent();
            answerRecorder = new AnswerRecorder(FileName.RESULTS_MULTIPLE_CHOICE);
            emailSender = new EmailSender(); ;
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            if (IsFormFilled())
            {
                WriteAnswers();
                Hide();
            }
            else
            {
                new NotificationPrompt().ShowFormNotFilledPrompt();
            }

        }

        private void WriteAnswers()
        {
            answerRecorder.WriteAnswer("", true);
            answerRecorder.WriteAnswer(ageBox.Text, true);
            answerRecorder.WriteAnswer(maleRadio.Checked ? "0" : "1", true);
            answerRecorder.WriteAnswer(majorDropDown.SelectedIndex.ToString(), false);
            Thread emailThread = new Thread(EmailAnswers);
            emailThread.Start();
        }

        private void EmailAnswers() {
            emailSender.EmailAnswers(this);
        }

        private void CloseApplication()
        {
            Environment.Exit(0);
        }

        private bool IsFormFilled()
        {
            return ageBox.Text.Length > 0 && majorDropDown.SelectedItem != null && (maleRadio.Checked || femaleRadio.Checked);
        }

        private void OnCloseRequired(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        public void OnEmailSent()
        {
            CloseApplication();
        }

        public void OnEmailSendingFailed()
        {
            CloseApplication();
        }
    }
}
