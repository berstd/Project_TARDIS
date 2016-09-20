using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            Human,
            Thorian,
            Xantorian
        }

        #endregion

        #region FIELDS

        private string _name;
        private string _spaceTimeLocationID;
        private RaceType _race;

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }



        #endregion


        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string SpaceTimeLocationID
        {
            get { return _spaceTimeLocationID; }
            set { _spaceTimeLocationID = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, string spaceTimeLocationID)
        {
            _name = name;
            _spaceTimeLocationID = spaceTimeLocationID;
        }

        #endregion


        #region METHODS



        #endregion




    }
}
