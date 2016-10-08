using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Jewel : SpaceTimeObject
    {
        public enum Type
        {
            Diamond,
            Ruby,
            Emerald,
            LodeStone
        }

        public override int GameObjectID { get; set; }

        public override string Name { get; set; }

        public override string Description { get; set; }

        public override int TimeSpaceLocationID { get; set; }

        public override bool HasValue { get; set; }

        public int Value { get; set; }

        public override bool CanAddToInventory { get; set; }
    }
}
