using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExIDFManagment.Interface
{
    public interface ICandidateCompanyStatusMangment
    {
        List<ICandidate> GetAllCandidateWithStatus(string Status);
        List<ICompany> GetAllCompaniesWithStatus(string Status);
        List<string> GetAllStatuses();
    }
}
