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



        #endregion

        #region ***** define methods to return game element objects *****



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
                Accessable = true
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

