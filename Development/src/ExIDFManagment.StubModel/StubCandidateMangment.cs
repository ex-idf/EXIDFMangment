using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.StubModel
{
    public class StubCandidateMangment : ICandidateManagment
    {
        private List<ICandidate> mCandidates;

        public StubCandidateMangment()
        {
            mCandidates = new List<ICandidate>();
            mCandidates.Add(new StubCandidate()
                                {
                                    DateOfBirth = new DateTime(1989,12, 20),
                                    ExcpectedSalary = 30000,
                                    ID = Guid.NewGuid().ToString(),
                                    Location = "תל אביב",
                                    Mail =  "nivpenso@gmail.com",
                                    MilitaryUnit =  "8200",
                                    Name = "ניב פנסו"
                                });
        }

        public bool AddCandidate(string name, DateTime dateOfBirth, string mail, int excpectedSalary, string cvPath, string militaryUnit, string location, string phone)
        {
            throw new NotImplementedException();
        }

        public bool CommitChanges()
        {
            throw new NotImplementedException();
        }

        public bool RemoveCandidate(ICandidate candidate)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCandidate(ICandidate candidate)
        {
            throw new NotImplementedException();
        }

        public ICandidate GetCandidate(string candidateId)
        {
            return mCandidates.Where(can => can.ID == candidateId).First();
        }

        public IEnumerable<ICandidate> GetAllCandidates()
        {
            return mCandidates;
        }


        public IEnumerable<ICandidateCompany> GetCandidateComapnies(string candidateId)
        {
            throw new NotImplementedException();
        }


        public void AttachCandidateToCompany(string candidateId, string companyId, DateTime attachTime, string status)
        {
            throw new NotImplementedException();
        }
    }
}
