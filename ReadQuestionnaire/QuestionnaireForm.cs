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
        public MainContainer()
        {
            InitializeComponent();

            Questionnaire questionnaire = new Questionnaire();

            Question currentQuestion = questionnaire.GetNextQuestion();
            questionTitle.Text = currentQuestion.title;
        }
    }
}
