using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ExIDFManagment.Interface
{
    public interface ICandidateCompany
    {
        ICandidate Candidate { get; set; }
        ICompany Company { get; set; }
        DateTime ExposeTime { get; set; }
        String Status { get; set; }
    }
}
