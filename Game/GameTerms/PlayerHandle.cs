using CardGame.Game.GameEvents;
using CardGame.Lib.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CardGame.Game.GameTerms
{
    public class PlayerHandle:HandleManager<Player>
    {
        readonly EventSystem _eventSystem;
        readonly Dictionary<string, Player> _players = new Dictionary<string, Player>();
        readonly Dictionary<Unit, Player> _unitOwners = new Dictionary<Unit, Player>();

        public PlayerHandle(EventSystem eventSystem)
        {
            _eventSystem = eventSystem;
        }
        public void newPlayer(Player p)
        {
            _players[p.name] = p;
            _eventSystem.getEventManager().emitEvent(new NewPlayer(p));
        }


    }
}
