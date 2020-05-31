using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Services
{
    public class NullMailServer : IMailServer
    {
        private readonly ILogger<NullMailServer> logger;
        
        public NullMailServer(ILogger<NullMailServer> logger)
        {
            this.logger = logger;
        }
        public void SendMail(string from, string subject, string message)
        {
            //wanna log the message
            logger.LogInformation("mail from{0},  about {1} , says ... {2}", from, subject, message);
        }
    }
}
