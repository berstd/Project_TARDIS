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
            SpaceTimeLocation spt = new SpaceTimeLocation();

            //
            // validate the ID value is withing the range of location IDs
            //
            if (ID > 0 && ID <= SpaceTimeLocations.Count())
            {
                //
                // run through the space-time location list and grab the correct one
                //
                foreach (SpaceTimeLocation location in SpaceTimeLocations)
                {
                    if (location.SpaceTimeLocationID == ID)
                    {
                        spt = location;
                    }
                }
            }
            //
            // throw and out of range exception to be caught and handled by the calling method
            //
            else
            {
                string feedbackMessage = $"Space-Time Location IDs must be between 1 and {SpaceTimeLocations.Count()}.";
                throw new ArgumentOutOfRangeException(ID.ToString(), feedbackMessage);
            }

            return spt;
        }
    }
}

