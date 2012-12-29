using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.DataModel
{
    public partial class Candidates : ICandidate
    {
        string ICandidate.ID
        {
            get { return this.PK; }
            set { _PK = value; }
        }
        string ICandidate.Name
        {
            get{ return this._Name; }
            set { _Name = value; }
        }
        DateTime ICandidate.DateOfBirth
        {
            get
            {
                if (_DateOfBirth == null)
                {
                    return DateTime.MaxValue;
                }
                return (DateTime)this._DateOfBirth;
            }
            set { this._DateOfBirth = value; }
        }
        int ICandidate.ExcpectedSalary
        {
            get { return this._Expected_Salary.GetValueOrDefault(); }
            set { this._Expected_Salary = value; }
        }
        string ICandidate.MilitaryUnit
        {
            get { return this._Military_Unit; }
            set { this._Military_Unit = value; }
        }
        string ICandidate.Location
        {
            get { return this._Location; }
            set { this._Location = value; }
        }
        string ICandidate.Mail
        {
            get { return this._Email; }
            set { this._Email = value; }
        }

        public override string ToString()
        {
            return this.Name;
        }
    
    }
}
