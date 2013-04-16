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

        private const string MESSAGE_ERROR = "Моля попълнете всички необходими данни";

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
            if (!IsFormFilled())
            {
                MessageBox.Show(MESSAGE_ERROR,
                "READ Експеримент",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }

            answerRecorder.WritePersonalInformation(ageBox.Text,maleRadio.Checked ? "0" : "1", majorDropDown.SelectedIndex.ToString());
            emailSender.EmailAnswers();
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
