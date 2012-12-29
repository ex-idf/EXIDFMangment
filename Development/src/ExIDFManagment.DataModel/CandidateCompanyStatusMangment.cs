using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.DataModel
{
    public class CandidateCompanyStatusMangment : ICandidateCompanyStatusMangment
    {
        public List<ICandidate> GetAllCandidateWithStatus(string status)
        {
            return
                EntitiesManager.Entity.Candidate_To_Employer.Where(cToC => cToC.Status == status).Select(
                    cToC => cToC.Candidates as ICandidate).ToList();
        }

        public List<ICompany> GetAllCompaniesWithStatus(string status)
        {
            return
                EntitiesManager.Entity.Candidate_To_Employer.Where(cToC => cToC.Status == status).Select(
                    cToC => cToC.Employers as ICompany).ToList();
        }

        public List<string> GetAllStatuses()
        {
            return EntitiesManager.Entity.CandidateStatus.Select(x=> x.Status).ToList();
        }
    }
}
