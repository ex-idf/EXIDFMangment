using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExIDFManagment.Interface;

namespace ExIDFManagment.DataModel
{
    public partial class Locations : ILocation
    {

        public string LocationName
        {
            get { return this._Location; }
            set { this._Location = value; }
        }
    }
}
