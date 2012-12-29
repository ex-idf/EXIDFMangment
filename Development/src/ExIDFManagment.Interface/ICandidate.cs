using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExIDFManagment.Interface
{
    public interface ICandidate
    {
        String ID { get; set; }
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        int ExcpectedSalary { get; set; }
        string MilitaryUnit { get; set; }
        string Location  { get; set; }
        string Mail { get; set; }
    }
}
