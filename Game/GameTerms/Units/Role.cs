using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms.Units
{
    public class Role : Token
    {
        public Role():base()
        {
            var handle = Global.getAbilityHandle();
            handle.abilityMoney.setAbility(this);
        }
    }

    public class Gov : Role
    {
        public Gov() : base()
        {
            var handle = Global.getAbilityHandle();
            handle.abilityCarry.setData(this);
        }
    }

    public class Police:Gov
    {
        
    }

}
