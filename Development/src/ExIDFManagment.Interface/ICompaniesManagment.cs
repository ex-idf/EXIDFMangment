using System.Collections.Generic;

namespace ExIDFManagment.Interface
{
    public interface ICompaniesManagment
    {
        IEnumerable<ICompany> GetCompanies();
        ICompany GetCompanyByID(string id);
        IEnumerable<ICandidateCompany> GetCompanyCandidates(string companyId);
        void Refresh();
    }
}
