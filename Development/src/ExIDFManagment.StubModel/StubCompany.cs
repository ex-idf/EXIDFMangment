using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.StubModel
{
    public class StubCompany : ICompany
    {
        public string ID { get; set; }

        public string CompanyName { get; set; }

        public string Location { get; set; }

        public string ContactName { get; set; }

        public string ContactMail { get; set; }

        public string ContactPhone { get; set; }

        public string ContractPath { get; set; }
    }
}
