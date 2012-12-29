using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.DataModel
{
    public class CandidateCompany : ICandidateCompany
    {
        public ICandidate Candidate { get; set; }
        public ICompany Company { get; set; }
        public DateTime ExposeTime { get; set; }
        public string Status { get; set; }
    }
}
