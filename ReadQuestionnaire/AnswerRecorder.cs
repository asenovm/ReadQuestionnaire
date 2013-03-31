using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReadQuestionnaire
{
    public class AnswerRecorder
    {
        private const string FILE_ANSWERS = "answers.dat";

        public void WriteAnswer(string question, string answer) {
            StreamWriter writer = File.AppendText(FILE_ANSWERS);
            writer.WriteLine();
            writer.Write(question);
            writer.WriteLine();
            writer.Write(answer);
            writer.WriteLine();
            writer.Close();
        }
    }
}
