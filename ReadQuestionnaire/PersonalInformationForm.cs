using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Read
{
    public partial class PersonalInformationForm : Form
    {

        private const string MESSAGE_ERROR = "Моля попълнете всички необходими данни";

        public PersonalInformationForm()
        {
            InitializeComponent();
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            if (!CanOpenExperimentForm())
            {
                MessageBox.Show(MESSAGE_ERROR,
                "READ Експеримент",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }

            string resultsFile = FileName.RESULTS_EXPERIMENT + Guid.NewGuid() + ".txt";
            FileUtil.WriteToFile(ageBox.Text, maleRadio.Checked ? "0" : "1", majorDropDown.SelectedIndex.ToString(), resultsFile);

            FormReadExperiment frm = new FormReadExperiment(resultsFile);

            this.Hide();
            frm.Show();
        }

        private bool CanOpenExperimentForm()
        {
            return ageBox.Text.Length > 0 && majorDropDown.SelectedItem != null && (maleRadio.Checked || femaleRadio.Checked);
        }

        private void OnCloseRequired(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
