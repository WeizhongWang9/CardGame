using CardGame.Game.GameTerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms
{


    // public enum Role { Police, Scientist, Dissident }
    public class Unit : ObjectOnMap
    {
        public int movePoint { set; get; }
        //    public Role role { set; get; }


        //public Unit(Player Owner, string name, string des, Role role, GameNode loc):base(Owner, name, des)
        //{
        //    this.loc = loc;
        //    this.role = role;
        //}
        public Unit(GameNode loc, Player Owner, string name, string des) : base(loc, Owner, name, des)
        {
        }

        public Unit() : this(null, null, "An unit", "Some units") { }
    }

    public class Dissident : Unit
    {
        int Wanted;
        public int wanted
        {
            get { return Wanted; }
            set
            {
                if (value < 0) value = 0;
            }
        }

        public int unrestSpreadSkill = 1;

    }

    public class Gov : Unit
    {
        public Body body { get; set; }

    }

    public class Police : Gov
    {

    }
    public class  Scientist: Gov
    {
        
    }
}
