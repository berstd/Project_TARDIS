using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Universe
    {
        public List<SpaceTimeLocation> SpaceTimeLocations { get; set; }

        public Universe()
        {
            this.SpaceTimeLocations = new List<SpaceTimeLocation>();
        }
        
        public SpaceTimeLocation GetSpaceTimeLocationByID(int ID)
        {
            //
            // run through the space-time location list and grab the correct one
            //
            foreach (SpaceTimeLocation location in SpaceTimeLocations)
            {
                if (location.SpaceTimeLocationID == ID)
                {
                    return location;
                }
            }
        }
    }
}

