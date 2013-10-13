using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Read
{
    public partial class TraitsInstructionForm : Form
    {

        public TraitsInstructionForm()
        {
            InitializeComponent();
        }

        private void OnBeginButtonClicked(object sender, EventArgs e)
        {
            Hide();
            new QuestionnaireForm(FileName.QUESTIONS_PERSONAL).Show();
        }

        private void OnCloseRequired(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
