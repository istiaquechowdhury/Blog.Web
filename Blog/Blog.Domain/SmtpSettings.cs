using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public class SmtpSettings
    {
        public string FromName { get; set; }        

        public string FromEmail { get; set; }   

        public string Host {  get; set; }

        public int Port { get; set; }
        
        public string Username { get; set; }    

        public string Password { get; set; }    

        public SmtpEncryptionTypes EncryptionType { get; set; } 
    }
}
