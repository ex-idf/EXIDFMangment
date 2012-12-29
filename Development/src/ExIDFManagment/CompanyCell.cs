using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExIDFManagment.Interface;

namespace ExIDFManagment
{
    public class CompanyCell : DataGridViewTextBoxCell
    {
        public ICompany Company { get; set; }

        public CompanyCell(ICompany company)
        {
            Company = company;
            ValueType = typeof (string);
        }

        protected override object GetValue(int rowIndex)
        {
            if (Company != null)
            {
                return Company.CompanyName;
            }
            return null;
        }
    }
}
