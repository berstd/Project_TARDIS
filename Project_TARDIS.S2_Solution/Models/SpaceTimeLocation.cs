using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class SpaceTimeLocation
    {
        #region FIELDS

        private string _name;
        private int _spaceTimeLocationID; // must be a unique value for each object
        private string _description;
        private bool _accessable;
        private List<Item> _items;
        private List<Treasure> _treasures;



        #endregion


        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int SpaceTimeLocationID
        {
            get { return _spaceTimeLocationID; }
            set { _spaceTimeLocationID = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Accessable
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        public List<Item> LocalItems
        {
            get { return _items; }
            set { _items = value; }
        }

        public List<Treasure> LocalTreasures
        {
            get { return _treasures; }
            set { _treasures = value; }
        }
        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion


    }
}
