using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.DataModel
{
    public class CompaniesManagment : ICompaniesManagment
    {
        public IEnumerable<ICompany> GetCompanies()
        {
            return EntitiesManager.Entity.Employers;
        }
    
        public ICompany GetCompanyByID(string id)
        {
            return EntitiesManager.Entity.Employers.Where(comp => comp.PK == id).First();
        }

        public void Refresh()
        {
            EntitiesManager.Entity.Refresh(RefreshMode.StoreWins, EntitiesManager.Entity.Employers);
        }

        public IEnumerable<ICandidateCompany> GetCompanyCandidates(string companyId)
        {
            IEnumerable<Candidate_To_Employer> candidateCompanies = null;
            List<CandidateCompany> results = new List<CandidateCompany>();
            try
            {
                candidateCompanies = EntitiesManager.Entity.Employers.
                    Where(comp => comp.PK == companyId).First().Candidate_To_Employer.AsEnumerable();
            }
            catch (Exception)
            {
                return null;
            }
            if (candidateCompanies != null)
            {
                foreach (var candidate in candidateCompanies)
                {
                    results.Add(new CandidateCompany()
                                    {
                                        Candidate = candidate.Candidates,
                                        Company = candidate.Employers,
                                        ExposeTime = candidate.Expose_Date.GetValueOrDefault(),
                                        Status = candidate.Status
                                    });
                }
                return results;
            }
            return null;
        }
    }
}
