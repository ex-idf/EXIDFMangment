using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.StubModel
{
    public class StubLocationManagement : ILocationManagment
    {
        public IEnumerable<ILocation> GetLocations()
        {
            return new List<ILocation>
                       {
                           new StubLocation()
                               {
                                   LocationName = "תל אביב"
                               },
                            new StubLocation()
                               {
                                   LocationName =  "חיפה"
                               }
                       };
        }
    }
}
