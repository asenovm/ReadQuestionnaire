using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace ReadQuestionnaire
{
    public class EmailSender
    {

        private const string MAIL_SENDER_ADDRESS = "read.experiment.mail.sender@gmail.com";

        private const string MAIL_RECEIVER_ADDRESS = "read-experiment@googlegroups.com";

        private const string MAIL_BODY = "Please find attached the results of a participant that has just filled our survey.";

        private const string MAIL_SUBJECT = "Read Questionnaire Result";

        private const string MAIL_SERVER_URL = "smtp.gmail.com";

        private const string MAIL_SENDER_NAME = "Read Expriment";

        private const string MAIL_RECEIVER_NAME = "Read Expriment Distribution List";

        private string senderPassword;

        public EmailSender() {
            StreamReader reader = new StreamReader("email.password");
            senderPassword = reader.ReadToEnd();
            reader.Close();
        }
        

        public void EmailAnswers() {
            var fromAddress = new MailAddress(MAIL_SENDER_ADDRESS, MAIL_SENDER_NAME);
            var toAddress = new MailAddress(MAIL_RECEIVER_ADDRESS, MAIL_RECEIVER_NAME);
            var message = new MailMessage(fromAddress, toAddress);
            var smtp = GetSmtpClient(fromAddress);

            message.Subject = MAIL_SUBJECT;
            message.Body = MAIL_BODY;
            message.Attachments.Add(new Attachment(AnswerRecorder.FILE_ANSWERS));
            smtp.Send(message);
        }

        private SmtpClient GetSmtpClient(MailAddress fromAddress) {
            return new SmtpClient
            {
                Host = MAIL_SERVER_URL,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, senderPassword)
            };        
        }
    }
}
