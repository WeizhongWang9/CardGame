using CardGame.Game.GameTerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms.PlayerUtility
{
    public class Team
    {
        protected List<Player> players = new List<Player>();
        public void AddPlayer(Player player) { players.Add(player); }
        public void RemovePlayer(Player player) { players.Remove(player); }
        public bool isSameTeam(Player player) { return players.Contains(player); }
    }

    
}
