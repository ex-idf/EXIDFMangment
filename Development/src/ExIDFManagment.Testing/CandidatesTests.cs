using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExIDFManagment.DataModel;

namespace ExIDFManagment.Testing
{
    [TestClass]
    public class CandidatesTests
    {
        ICandidateManagment candidatesManager = new CandidatesManagment();

        public void AddCandidate(ICandidate candidate)
        {
            //Assert.IsTrue(candidatesManager.AddCandidate()); // Test logic + Assertion
        }

        [TestMethod]
        public void AddCandidateTest()
        {
            ICandidate candidate = new Candidates()                     // Initialize Test Parameters
                            {
                                PK = Guid.NewGuid().ToString(),
                                CV_Path = "",
                                DateOfBirth = new DateTime(1989, 12, 20),
                                Email = "dd@dd.co.il",
                                Expected_Salary = 25000,
                                Location = "TelAviv",
                                Military_Unit = "8200",
                                Name = "Niv"
                            };
            AddCandidate(candidate);
            CandidatesManagment temp = candidatesManager as CandidatesManagment;
            if (temp != null)
            {
                Assert.IsTrue(temp.Entity.Candidates.Any(candi => candi.Name.Equals(candidate.Name)));
            }
        }
    }
}
