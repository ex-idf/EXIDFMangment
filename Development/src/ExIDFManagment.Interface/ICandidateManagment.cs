using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExIDFManagment.Interface
{
    public interface ICandidateManagment
    {
        bool AddCandidate(string name, DateTime dateOfBirth, string mail, int excpectedSalary, string cvPath, string militaryUnit, string location, string phone);
        bool CommitChanges();
        bool RemoveCandidate(ICandidate candidate);
        bool UpdateCandidate(ICandidate candidate);
        void Refresh();
        ICandidate GetCandidate(string candidateId);
        IEnumerable<ICandidate> GetCandidateContainsName(string name);
        IEnumerable<ICandidate> GetAllCandidates();
        IEnumerable<ICandidateCompany> GetCandidateComapnies(string candidateId);
        void AttachCandidateToCompany(string candidateId, string companyId, DateTime attachTime, string status);
        void UpdateCandidateToCompanyStatus(string candidateId, string comapnyId, DateTime attachTime, string status);
        void SendWelcomeMail(string candidateId);
    }
}
