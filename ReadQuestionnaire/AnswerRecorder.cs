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

        private string filePathOpenQuestions;

        private string filePathMultipleChoiceQuestions;

        public AnswerRecorder(string filePathOpenQuestions, string filePathMultipleChoiceQuestions)
        {
            this.filePathOpenQuestions = filePathOpenQuestions;
            this.filePathMultipleChoiceQuestions = filePathMultipleChoiceQuestions;
        }

        public void WriteAnswer(Question question, RadioGroup group, Control container, TextBox answerBox, bool isLastQuestion)
        {
            switch (question.type)
            {
                case QuestionType.OPEN:
                    WriteOpenAnswer(answerBox.Text);
                    break;
                case QuestionType.MULTIPLE_CHOICE:
                    QuestionRadioControl radioControl = GetControl(container) as QuestionRadioControl;
                    WriteAnswer(group.GetCheckedValue(), !isLastQuestion);
                    break;
                default:
                    QuestionTable table = GetControl(container) as QuestionTable;
                    WriteAnswer(table.GetValue(), !isLastQuestion);
                    break;
            }
        }

        public string GetOpenAnswer()
        {
            return filePathOpenQuestions;
        }

        public string GetMultipleChoiceAnswer()
        {
            return filePathMultipleChoiceQuestions;
        }

        private void WriteOpenAnswer(string answer)
        {
            StreamWriter writer = File.AppendText(filePathOpenQuestions);
            writer.WriteLine();
            writer.Write(answer);
            writer.WriteLine();
            writer.Close();
        }

        private void WriteAnswer(string answer, bool isAddingDelimiter)
        {
            StreamWriter writer = File.AppendText(filePathMultipleChoiceQuestions);
            writer.Write(answer);
            if (isAddingDelimiter)
            {
                writer.Write(",");
            }
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
