using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms.Abilities
{
    public class AbilityNeighborhood : AbilityUnitKeeping
    {
        public AbilityNeighborhood(Game game) : base(game)
        {
        }

        public bool isNeighbor(Unit unit, Unit unitChecked)
        {
            if (datas.TryGetValue(unit, out var data))
            {
                return data.attribute.units.Contains(unitChecked);
            }
            return false;
        }
    }
}
