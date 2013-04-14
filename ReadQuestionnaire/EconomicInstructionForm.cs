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
    public partial class EconomicInstructionForm : Form
    {
        private string outputFileId;

        public EconomicInstructionForm(string outputFileId)
        {
            InitializeComponent();
            this.outputFileId = outputFileId;
        }

        private void OnBeginButtonClicked(object sender, EventArgs e)
        {
            Hide();
            new MainContainer(outputFileId, "questions.dat").Show();
        }

    }
}
