using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBank.Models
{
    public class Tweet
    {

        public string Header { get; set; }
        public string Sender { get; set; }
        public string Body { get; set; }

        public Tweet()
        {
            Header = string.Empty;
            Sender = string.Empty;
            Body = string.Empty;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}" + "\n\n" + "Sender: {1}" + "\n\n" + "{2}",
                this.Header, this.Sender, this.Body);
        }
    }
}
