using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExIDFManagment.Interface
{
    public interface ICompany
    {
        String ID { get; set; }
        String CompanyName { get; set; }
        String Location { get; set; }
        String ContactName { get; set; }
        String ContactMail { get; set; }
        String ContactPhone { get; set; }
        String ContractPath { get; set; }
    }
}
