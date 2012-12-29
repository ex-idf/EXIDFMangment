using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExIDFManagment.DataModel
{
    public class EntitiesManager
    {
        public readonly static Entities Entity;
        static EntitiesManager()
        {
            Entity = new Entities();
        }
    }
}
