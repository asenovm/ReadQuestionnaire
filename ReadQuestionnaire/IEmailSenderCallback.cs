using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Read
{
    public interface IEmailSenderCallback
    {
        void OnEmailSent();

        void OnEmailSendingFailed();
    }
}
