using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.StubModel
{
    public class StubCompaniesManagment : ICompaniesManagment
    {
        private IEnumerable<ICompany> mCompaniesList;

        public StubCompaniesManagment()
        {
            mCompaniesList = new List<ICompany>
                       {
                           new StubCompany()
                               {
                                   CompanyName = "NSO",
                                   ContactMail = "dd@dd.com",
                                   ContactName = "Shani",
                                   ContactPhone = "036495001",
                                   ContractPath = "ddd.xml",
                                   ID = Guid.NewGuid().ToString(),
                                   Location = new StubLocation()
                                                  {
                                                      LocationName = "תל אביב"
                                                  }.LocationName
                               },
                           new StubCompany()
                               {
                                   CompanyName = "Linkury",
                                   ContactMail = "dd@dd.com",
                                   ContactName = "Pavel",
                                   ContactPhone = "036495001",
                                   ContractPath = "ccc.xml",
                                   ID = Guid.NewGuid().ToString(),
                                   Location = new StubLocation()
                                                  {
                                                      LocationName = "תל אביב"
                                                  }.LocationName
                               }
                       };
        }

        public IEnumerable<ICompany> GetCompanies()
        {
            return mCompaniesList;
        }

        public ICompany GetCompanyByID(string id)
        {
            return mCompaniesList.Where(comp => comp.ID == id).First();
        }


        public IEnumerable<ICandidateCompany> GetCompanyCandidates(string companyId)
        {
            throw new NotImplementedException();
        }
    }
}
