using CardGame.Game.GameTerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CardGame.Game.GameTerms
{
    public class Token : ObjectOnMap
    {
        public Token(GameNode loc, Player Owner, string name, string des) : base(loc, Owner, name, des) { }
    }
    public class Body : Token
    {
        public Body(GameNode loc, Player Owner, string name, string des) : base(loc, Owner, name, des)
        {
        }
    }
}
