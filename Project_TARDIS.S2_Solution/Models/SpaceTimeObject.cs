using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public abstract class SpaceTimeObject
    {
        #region FIELDS

        #endregion

        #region PROPERTIES

        public abstract int GameObjectID { get; set; }

        public abstract string Name { get; set; }

        public abstract string Description { get; set; }

        public abstract int TimeSpaceLocationID { get; set; }

        public abstract bool HasValue { get; set; }

        public abstract bool CanAddToInventory { get; set; }

        #endregion


        #region CONSTRUCTORS

        public SpaceTimeObject() { }

 
        #endregion


        #region METHODS

        public virtual string SpaceTimeTransporterMessage()
        {
            string gameObjectMessage = ($"The {this.Name}. is not a Space-Time transport device.");

            return gameObjectMessage;
        }
        
        #endregion




    }
}
