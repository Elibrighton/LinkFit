using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
        public string FacebookAppId { get; set; }
        public string FacebookAppSecret { get; set; }
    }
}
