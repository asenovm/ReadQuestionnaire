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
    public partial class PersonalInformationForm : Form
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
                CloseApplication();
            }
            else
            {
                new NotificationPrompt().ShowFormNotFilledPrompt();
            }

        }

        private void WriteAnswers()
        {
            answerRecorder.WritePersonalInformation(ageBox.Text, maleRadio.Checked ? "0" : "1", majorDropDown.SelectedIndex.ToString());
            emailSender.EmailAnswers();
        }

        private void CloseApplication()
        {
            Close();
            Application.Exit();
            Process.GetCurrentProcess().Kill();
        }

        private bool IsFormFilled()
        {
            return ageBox.Text.Length > 0 && majorDropDown.SelectedItem != null && (maleRadio.Checked || femaleRadio.Checked);
        }

        private void OnCloseRequired(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
