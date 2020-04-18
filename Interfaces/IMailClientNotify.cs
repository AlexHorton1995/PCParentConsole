using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PCParentConsole.Interfaces
{
    public interface IMailClientNotify
    {
        MailAddress ToEmail { get; set; }
        string FromEmail { get; set; }
        string Subject { get; set; }
        string EmailBody { get; set; }
        string SMTPServer { get; set; }
        int SMTPPort { get; set; }
        bool SendEmailNotification(int notifyType);
    }
}
