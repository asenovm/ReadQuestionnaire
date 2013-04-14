using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadQuestionnaire
{
    public class Option
    {

        public string header;

        public int value;

        public Option(string header, int value)
        {
            this.header = header;
            this.value = value;
        }
    }
}
