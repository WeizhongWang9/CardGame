using CardGame.Game.GameEvents;
using CardGame.Game.GameTerms;
using CardGame.Game.GameTerms.Units;
using CardGame.Lib.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game
{
    public class Global
    {
        static Global global;

        public static Global Get() => global;
        public static Game getGame() => Get().game;
        public static EventManager getEventManager() => getGame().eventManager;
        public static UnitHandle getUnitHandle() => getGame().unitHandle;
        public static AbilityHandle getAbilityHandle() => getGame().abilityHandle;
        public static Map GetMap() => getGame().map;
        Game game = new Game();
        public static void Init()
        {
            global = new Global();

        }
    }
}
