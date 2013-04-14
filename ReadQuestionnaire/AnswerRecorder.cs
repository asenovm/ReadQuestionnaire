using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace Read
{
    public class AnswerRecorder
    {
        public static string FILE_ANSWERS = "answers.txt";

        public static string FILE_ANSWERS_OPEN_QUESTIONS = "answers_open_questions.txt";

        public AnswerRecorder()
        {
            if (File.Exists(FILE_ANSWERS))
            {
                File.Delete(FILE_ANSWERS);
            }

            if (File.Exists(FILE_ANSWERS_OPEN_QUESTIONS))
            {
                File.Delete(FILE_ANSWERS_OPEN_QUESTIONS);
            }
        }

        public void WriteAnswer(Question question, RadioGroup group, Control container, TextBox answerBox)
        {
            switch (question.type)
            {
                case QuestionType.OPEN:
                    WriteOpenAnswer(answerBox.Text);
                    break;
                case QuestionType.MULTIPLE_CHOICE:
                    QuestionRadioControl radioControl = GetControl(container) as QuestionRadioControl;
                    WriteAnswer(group.GetCheckedValue());
                    break;
                default:
                    QuestionTable table = GetControl(container) as QuestionTable;
                    WriteAnswer(table.GetValue());
                    break;
            }
        }

        private void WriteOpenAnswer(string answer) {
            StreamWriter writer = File.AppendText(FILE_ANSWERS_OPEN_QUESTIONS);
            writer.Write(answer);
            writer.WriteLine();
            writer.Close();        
        }

        private void WriteAnswer(string answer)
        {
            StreamWriter writer = File.AppendText(FILE_ANSWERS);
            writer.Write(answer);
            writer.Write(",");
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
