using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExIDFManagment.Interface
{
    public interface ILocationManagment
    {
        IEnumerable<ILocation> GetLocations();
        void Refresh();
    }
}
