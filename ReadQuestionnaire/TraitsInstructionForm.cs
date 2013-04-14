﻿using System;
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
        private string outputFileId;

        public TraitsInstructionForm(string outputFileId)
        {
            InitializeComponent();
            this.outputFileId = outputFileId;
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            Hide();
            new MainContainer(outputFileId, "questions_traits.dat").Show();
        }
    }
}