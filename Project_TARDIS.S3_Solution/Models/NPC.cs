using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class NPC : Character
    {
        #region FIELDS
        private string _message;

        #endregion

        #region PROPERTIES

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public bool HasMessage { get { return _message != null && _message.Length !=0; } set { } }

        #endregion


        #region CONSTRUCTORS
        //public NPC();
        //public NPC(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        //{

        //}

        #endregion


        #region METHODS



        #endregion
    }
}
