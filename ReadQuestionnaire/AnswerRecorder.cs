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

        private string resultsFilePath;

        private static string ANSWER_DELIMITER = ",";

        public AnswerRecorder(string resultsFilePath) {
            this.resultsFilePath = resultsFilePath;
        }

        public void WriteAnswer(string answer) {
            WriteAnswer(answer, false, true);
        }

        public void WriteAnswer(string answer, bool isAddingDelimiter)
        {
            WriteAnswer(answer, isAddingDelimiter, false);
        }

        private void WriteAnswer(string answer, bool isAddingDelimiter, bool isAddingNewLine) {
            StreamWriter writer = File.AppendText(resultsFilePath);

            if (isAddingNewLine) {
                writer.WriteLine();
            }

            writer.Write(answer);

            if (isAddingDelimiter) {
                writer.Write(ANSWER_DELIMITER);
            }

            if (isAddingNewLine) {
                writer.WriteLine();
            }

            writer.Close();
        }

    }
}
