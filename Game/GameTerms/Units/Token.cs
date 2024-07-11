using CardGame.Game.GameTerms.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms.Units
{
    /// <summary>
    /// Every object that can be attached on a game node is a token.
    /// For example, characters and game tokens.
    /// A card is not a token as it attachs to a player.
    /// </summary>
    public class Token : Unit
    {
        GameNode _loc;

        public GameNode loc { get { return _loc; } set { _loc = value; } }

        public Token()
        {
        }
    }

}
