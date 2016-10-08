using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// the Universe class manages all of the game elements
    /// </summary>
    public class Universe
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all space-time locations
        //
        public List<SpaceTimeLocation> SpaceTimeLocations { get; set; }


        #endregion

        #region ***** constructor *****

        //
        // default Universe constructor
        //
        public Universe()
        {
            //
            // instantiate the lists of space-time locations and game objects
            //
            this.SpaceTimeLocations = new List<SpaceTimeLocation>();

            //
            // add all of the space-time locations and game objects to their lists
            // 
            IntializeUniverseSpaceTimeLocations();
        }

        #endregion

        #region ***** define methods to get the next available ID for game elements *****

        /// <summary>
        /// return the next available ID for a SpaceTimeLocation object
        /// </summary>
        /// <returns>next SpaceTimeLocationObjectID </returns>
        private int GetNextSpaceTimeLocationID()
        {
            int MaxID = 0;

            foreach (SpaceTimeLocation STLocation in SpaceTimeLocations)
            {
                if (STLocation.SpaceTimeLocationID > MaxID)
                {
                    MaxID = STLocation.SpaceTimeLocationID;
                }
            }

            return MaxID + 1;
        }

        #endregion

        #region ***** define methods to return game element objects *****

        /// <summary>
        /// get a SpaceTimeLocation object using an ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>requested space-time location</returns>
        public SpaceTimeLocation GetSpaceTimeLocationByID(int ID)
        {
            SpaceTimeLocation spt = new SpaceTimeLocation();

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

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (spt == null)
            {
                string feedbackMessage = $"The Space-Time Location ID {ID} does not exist in the current Universe.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return spt;
        }

        #endregion

        #region ***** define methods to get lists of game elements by location *****


        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the universe with all of the space-time locations
        /// </summary>
        private void IntializeUniverseSpaceTimeLocations()
        {
            SpaceTimeLocations.Add(new SpaceTimeLocation
            {
                Name = "TARDIS Base",
                SpaceTimeLocationID = 1,
                Description = "The Norlon Corporation's secret laboratory located deep underground, " +
                              " beneath a nondescript 7-11 on the south-side of Toledo, OH.",
                Accessable = true
            });

            SpaceTimeLocations.Add(new SpaceTimeLocation
            {
                Name = "Xantoria Market",
                SpaceTimeLocationID = 2,
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
                              "open market managed by the Xantorian Commerce Coop. It is a place " +
                              "where many races from various systems trade goods.",
                Accessable = false
            });

            SpaceTimeLocations.Add(new SpaceTimeLocation
            {
                Name = "Felandrian Plains",
                SpaceTimeLocationID = 3,
                Description = "The Felandrian Plains are a common destination for tourist. " +
                  "Located just north of the equatorial line on the planet of Corlon, they" +
                  "provide excellent habitat for a rich ecosystem of flora and fauna.",
                Accessable = true
            });
        }

        #endregion

    }
}

