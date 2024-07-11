using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms.Units
{
    public class Map
    {

    }
    public class GameNode : Unit
    {
        public GameNode():base()
        {
            var handle = Global.getAbilityHandle();
            handle.abilityGameNodeKeepUnits.setData(this);
            handle.abilityGameNodeNeighborhood.setData(this);
            handle.abilityGameNodeChaoticMeasure.setData(this);
        }
        public void addChaoticMeasure(int val)
        {
            var ability = Global.getAbilityHandle().abilityGameNodeChaoticMeasure;
            ability.getAttribute(this).property += val;
        }
        public void setChaoticMeasure(int val)
        {
            var ability = Global.getAbilityHandle().abilityGameNodeChaoticMeasure;
            ability.getAttribute(this).property = val;
        }

        public void addUnitOnGameNode(Token unit)
        {
            var handle = Global.getAbilityHandle();
            var keepUnits = handle.abilityGameNodeKeepUnits;
            keepUnits.getAttribute(this).addUnit(unit);
            unit.loc = this;
        }

        public void removeUnitOnGameNode(Token unit)
        {
            var handle = Global.getAbilityHandle();
            var keepUnits = handle.abilityGameNodeKeepUnits;
            keepUnits.getAttribute(this).removeUnit(unit);
            unit.loc = null;
        }
        public void addUnitOnMap(Token unit)
        {
            var prevGameNode = unit.loc;
            prevGameNode.removeUnitOnGameNode(unit);
            this.addUnitOnGameNode(unit);
        }


        public void addNeighborhood(GameNode gameNode)
        {
            var handle = Global.getAbilityHandle();
            var ability = handle.abilityGameNodeNeighborhood;
            ability.getAttribute(this).addUnit(gameNode);
        }

        public bool isNeighbor(GameNode gameNode)
        {
            return Global.getAbilityHandle().abilityGameNodeNeighborhood.isNeighbor(this,gameNode);
        }
    }
}
