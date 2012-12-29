using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.DataModel
{
    public partial class Employers : ICompany
    {
        string ICompany.ID
        {
            get { return this._PK; }
            set { this._PK = value; }
        }
        string ICompany.CompanyName
        {
            get { return this._CompanyName; }
            set { this._CompanyName = value; }
        }
        String ICompany.Location
        {
            get { return this._Location; }
            set { this._Location = value; }
        }
        string ICompany.ContactName
        {
            get { return this._ContactName; }
            set { this._ContactName = value; }
        }
        string ICompany.ContactMail
        {
            get { return this._ContactEmail; }
            set { this._ContactEmail = value; }
        }
        string ICompany.ContactPhone
        {
            get { return this._Phone; }
            set { this._Phone = value; }
        }
        string ICompany.ContractPath
        {
            get { return this._ContractPath; }
            set { this._ContractPath = value; }
        }

        public override string ToString()
        {
            return this.CompanyName;
        }
    }
}
