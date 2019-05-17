using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBank.Models
{
    public class Email
    {
        public string Header { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string SortCode { get; set; }
        public string Incident { get; set; }
        public string Body { get; set; }

        public ObservableCollection<string> IncidentList
        {
            get;
            set;
        }

        public Email()
        {
            Header = string.Empty;
            Sender = string.Empty;
            Subject = string.Empty;
            Incident = string.Empty;
            SortCode = string.Empty;
            Body = string.Empty;

            IncidentList = new ObservableCollection<string>()
            {
                "-- Select --",
                "Theft",
                "Staff Attack",
                "ATM Theft",
                "Raid",
                "Customer Attack",
                "Staff Abuse",
                "Bomb Threat",
                "Terrorism",
                "Suspicious Incident",
                "Intelligence",
                "Cash Loss"
            };
        }

        public override string ToString()
        {
            return string.Format("ID: {0}" + "\n\n" + "Sender: {1}" + "\n" + "Subject: {2}" + "\n\n" + "Incident: {3}" + "\n" + "Sort Code: {4}"+ "\n\n"+ "{5}",
                this.Header, this.Sender, this.Subject, this.Incident, this.SortCode, this.Body);
        }
    }
}
