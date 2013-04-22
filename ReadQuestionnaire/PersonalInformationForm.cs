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

namespace Read
{
    public partial class PersonalInformationForm : Form, IEmailSenderCallback
    {

        private AnswerRecorder answerRecorder;

        private EmailSender emailSender;

        public PersonalInformationForm(AnswerRecorder recorder, EmailSender sender)
        {
            InitializeComponent();
            answerRecorder = recorder;
            emailSender = sender;
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            if (IsFormFilled())
            {
                WriteAnswers();
            }
            else
            {
                new NotificationPrompt().ShowFormNotFilledPrompt();
            }

        }

        private void WriteAnswers()
        {
            answerRecorder.WritePersonalInformation(ageBox.Text, maleRadio.Checked ? "0" : "1", majorDropDown.SelectedIndex.ToString());
            emailSender.EmailAnswers(this);
        }

        private void CloseApplication()
        {
            Close();
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
