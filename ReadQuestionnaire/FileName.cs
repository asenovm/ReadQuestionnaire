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

        private static Guid UID= Guid.NewGuid();

        public static string CONFIGURATION_CLIENT = "client.dat";

        public static string RESULTS_EXPERIMENT = "results_experiment_" + UID + ".txt";

        public static string RESULTS_OPEN_ANSWER = "results_questionnaire_open_" + UID + ".txt";

        public static string RESULTS_MULTIPLE_CHOICE = "results_questionnaire_multiple_choice_" + UID + ".txt";

        public static string RESULTS_EXPERIMENT_NOTIFICATIONS = "results_experiment_notifications_" + UID + ".txt";

        public static string QUESTIONS_ECONOMIC = "questions.dat";

        public static string QUESTIONS_PERSONAL = "questions_traits.dat";

        public static string QUESTIONS_OFFERS = "SuppliersOffers.txt";
    }
}
