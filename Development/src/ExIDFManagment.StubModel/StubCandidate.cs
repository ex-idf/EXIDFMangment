using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.StubModel
{
    public class StubCandidate : ICandidate
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ExcpectedSalary { get; set; }

        public string MilitaryUnit { get; set; }

        public string Location { get; set; }

        public string Mail { get; set; }
    }
}
