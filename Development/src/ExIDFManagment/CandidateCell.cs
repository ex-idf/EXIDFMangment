using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExIDFManagment.Interface;

namespace ExIDFManagment
{
    public class CandidateCell : DataGridViewTextBoxCell
    {
        public ICandidate Candidate { get; set; }
        public CandidateCell(ICandidate candidate) : base()
        {
            Candidate = candidate;
            ValueType = typeof (string);
        }

        protected override object GetValue(int rowIndex)
        {
            if (Candidate != null)
            {
                return Candidate.Name;
            }
            return null;
        }
    }
}
