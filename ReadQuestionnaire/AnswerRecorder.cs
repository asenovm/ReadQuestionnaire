using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace ReadQuestionnaire
{
    public class AnswerRecorder
    {
        public static string FILE_ANSWERS = "answers.dat";

        public AnswerRecorder() {
            StreamWriter writer = File.CreateText(FILE_ANSWERS);
            writer.Close();
        }

        public void WriteAnswer(Question question, RadioGroup group, Control container, TextBox answerBox)
        {
            switch (question.type)
            {
                case QuestionType.OPEN:
                    WriteAnswer(question.title, answerBox.Text);
                    break;
                case QuestionType.MULTIPLE_CHOICE:
                    QuestionRadioControl radioControl = GetControl(container) as QuestionRadioControl;
                    WriteAnswer(question.title, group.GetCheckedValue());
                    break;
                default:
                    QuestionTable table = GetControl(container) as QuestionTable;
                    WriteAnswer(question.title, table.GetValue());
                    break;
            }
        }

        
        private void WriteAnswer(string question, string answer) {
            StreamWriter writer = File.AppendText(FILE_ANSWERS);
            writer.WriteLine();
            writer.Write(question);
            writer.WriteLine();
            writer.Write(answer);
            writer.WriteLine();
            writer.Close();        
        }

        private Control GetControl(Control container)
        {
            IEnumerator enumerator = container.Controls.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current as Control;
        }

    }
}
