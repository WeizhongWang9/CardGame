using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using CardGame.Lib.EventSystem;
using CardGame.Game.GameTerms;
using CardGame.GameEvents.Info;
using CardGame.Game.GameTerms.Cards;
namespace CardGame.GameEvents.Events
{ 
    public class UnitEvents
    {
        public static GenericEvent<InfoUnitMove> UnitMove = new GenericEvent<InfoUnitMove>();
        public static GenericEvent<InfoObjectOn<Unit, int>> UnitGetMoney = new GenericEvent<InfoObjectOn<Unit, int>>();
        
    }
    public class DissEvents
    {
        public static GenericEvent<InfoObjectOn<Dissident, Place>> SpreadUnrest = new GenericEvent<InfoObjectOn<Dissident, Place>>();
        //public static GenericEvent<InfoObjectEvent<Dissident>> DissAddToken = new GenericEvent<InfoObjectEvent<Dissident>>();
        public static GenericEvent<InfoObjectOn<Dissident, int>> IncreaseWanted = new GenericEvent<InfoObjectOn<Dissident, int>>();
    }

    public class GovEvents
    {
        public static GenericEvent<InfoObjectOn<Police, Dissident>> Arrest = new GenericEvent<InfoObjectOn<Police, Dissident>>();
        public static GenericEvent<InfoObjectOn<Police, Place>> PlaceControl = new GenericEvent<InfoObjectOn<Police, Place>>();
        public static GenericEvent<InfoObjectOn<Gov, Body>> GovPickupBody = new GenericEvent<InfoObjectOn<Gov, Body>>();
        public static GenericEvent<InfoObjectOn<Scientist, BodyPlaceCard>> SciGetBodyPlaceCard = new GenericEvent<InfoObjectOn<Scientist, BodyPlaceCard>>();
        
    }

    public class GameNodeEvents
    {
        public static GenericEvent<InfoUnrestIncrease> IncreasePlaceUnrest = new GenericEvent<InfoUnrestIncrease>();

    }

    public class CardEvents
    {
        /// <summary>
        /// Player plays a card.
        /// </summary>
        public static GenericEvent<InfoCardPlay> CardPlay = new GenericEvent<InfoCardPlay>();
        public static GenericEvent<InfoCardPlayOnTarget<Player>> CardPlayOnTargetPlayer = new GenericEvent<InfoCardPlayOnTarget<Player>>();
        public static GenericEvent<InfoCardPlayOnTarget<Unit>> CardPlayOnTargetUnit = new GenericEvent<InfoCardPlayOnTarget<Unit>>();
        public static GenericEvent<InfoCardPlayOnTarget<GameNode>> CardPlayOnMap = new GenericEvent<InfoCardPlayOnTarget<GameNode>>();
    }

    public class PlayerEvents
    {
        public static GenericEvent<InfoPlayerBuy> BuyCard = new GenericEvent<InfoPlayerBuy>();
    }


}