using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.DataModel
{
    public class LocationsManagment : ILocationManagment
    {
        public IEnumerable<ILocation> GetLocations()
        {
            return EntitiesManager.Entity.Locations.AsEnumerable();
        }

        public void Refresh()
        {
            EntitiesManager.Entity.Refresh(RefreshMode.StoreWins, EntitiesManager.Entity.Locations);
        }
    }
}
