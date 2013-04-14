using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Read
{
    public class FileName
    {
        private FileName()
        {
            //blank
        }

        public static string RESULTS_EXPERIMENT = "results_experiment_";

        public static string RESULTS_OPEN_ANSWER = "results_questionnaire_open_";

        public static string RESULTS_MULTIPLE_CHOICE = "results_questionnaire_multiple_choice_";

        public static string QUESTIONS_ECONOMIC = "questions.dat";

        public static string QUESTIONS_PERSONAL = "questions_traits.dat";

        public static string QUESTIONS_OFFERS = "SuppliersOffers.txt";
    }
}
