using CardGame.Game.GameEvents;
using CardGame.Game.GameTerms;
using CardGame.Game.GameTerms.Abilities;
using CardGame.Game.GameTerms.Units;
using CardGame.Lib.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game
{
    public class Game
    {
        readonly UnitHandle _handleManagerUnit = new UnitHandle();
        readonly EventManager _eventManager = new EventManager();
        readonly AbilityHandle _abilityHandle;
        readonly Map _map;
        public UnitHandle unitHandle => _handleManagerUnit;
        public EventManager eventManager => _eventManager;
        public AbilityHandle abilityHandle => _abilityHandle;
        public Map map => _map;
        public Game() {
            _abilityHandle = new AbilityHandle(this);
            _map = new Map();
        }
    }

    public class AbilityHandle
    {
        Game game;
        public AbilityWanted abilityWanted;
        public AbilityMove abilityMove;
        public AbilityOrder abilityOrder;
        public AbilityUnitKeeping abilityGameNodeKeepUnits;
        public AbilityNeighborhood abilityGameNodeNeighborhood;

        public AbilityHandle(Game game)
        {
            this.game = game;
            abilityWanted = new AbilityWanted(game);
            abilityMove = new AbilityMove(game);
            abilityOrder = new AbilityOrder(game);
            abilityGameNodeKeepUnits = new AbilityUnitKeeping(game);
            abilityGameNodeNeighborhood = new AbilityNeighborhood(game);
        }
    }
}
